# Fase 02: Multiplayer local

**Marco:** Protótipo
**Status:** concluída

## Objetivo

Dois jogadores na mesma ilha, se vendo e se empurrando, com o FishNet no transporte Tugboat.

## Escopo

- Instalar o FishNet (versão gratuita), preso na tag `4.7.3`.
- Instalar o Multiplayer Play Mode (`com.unity.multiplayer.playmode`) para testar vários jogadores no mesmo PC.
- NetworkManager com Tugboat, para host e cliente. O `NetworkBootstrap` inicia sozinho: o editor principal vira host, as instâncias adicionais do Multiplayer Play Mode viram clientes, e build e solo sobem como host.
- Spawn do jogador em rede, com o movimento do próprio jogador sob autoridade do cliente (`NetworkTransform` client authoritative). Só o dono tem input, câmera, motor e física; nos outros o corpo é kinematic.
- Empurrão simples, sem arma, com knockback: a base do combate. Attack (botão esquerdo, X no controle) mira à frente; o servidor valida alcance e intervalo e o dono do alvo aplica o impulso, com um instante sem controle.
- Quem cai da ilha renasce no totem, em rede.
- Solo continua funcionando como host sem clientes.

## Fora do escopo

- Steam (fase 05) e voz (fase 06).
- Armas (fase 12).

## Critérios de pronto

- [x] Dois jogadores no Multiplayer Play Mode se veem e se movem sem tremer.
- [x] Empurrão funciona nos dois sentidos: host empurra cliente e cliente empurra host.
- [x] Queda e renascimento no totem funcionam para host e cliente.
- [x] Solo continua funcionando.
- [x] Testes de Edit Mode para as regras novas.
- [x] Usuário testou com dois jogadores e aprovou.

## Bugs prováveis

- Empurrão ignorado porque o jogador empurrado tem autoridade sobre o próprio movimento: o impulso precisa ser aplicado no cliente dono, via RPC direcionado a ele.
- Câmera ou input de um jogador controlando o outro (ativar só para o dono).
- Jogador nascendo dentro de outro ou fora da ilha.
- Comportamento diferente entre host e cliente puro.

## Referências

- GDD: Combate.
- `CLAUDE.md`: Regras de multiplayer.
