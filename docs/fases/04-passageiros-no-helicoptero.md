# Fase 04: Passageiros no helicóptero

**Marco:** Protótipo
**Status:** em andamento

## Objetivo

Os outros jogadores ficam em pé dentro do helicóptero em movimento, estáveis, em rede. É a parte mais difícil do protótipo.

## Escopo

- Quem está dentro do helicóptero acompanha o veículo como plataforma móvel.
- Caminho: o mesmo do piloto (fase 03). Ao entrar no volume da cabine, o passageiro ganha parent em rede no helicóptero e acompanha o transform dele; ao sair, perde o parent. Na máquina de cada passageiro o helicóptero é kinematic e anda pelo `NetworkTransform`, então a velocidade do Rigidbody embaixo não serve de referência.
- Ao entrar, a velocidade do passageiro passa a ser relativa ao helicóptero; ao sair, ele herda a velocidade do helicóptero, estimada pelo movimento do transform.
- A direção de andar do `PlayerMotor` soma a rotação do corpo, que gira junto com o helicóptero.
- Entrar e sair andando, inclusive pulando do helicóptero em voo.
- Até 4 jogadores: um piloto e três passageiros. Cabine maior, com grades laterais baixas: seguram quem anda, mas um empurrão ainda joga alguém para fora.

## Fora do escopo

- Estações de apoio: conserto, canhão, guincho e reviver (fase 14).
- Inclinação visual afetando a física.

## Critérios de pronto

- [ ] Passageiros não tremem, não atravessam o chão e não escorregam em voo, curva e subida.
- [ ] Funciona para host e clientes, testado no Multiplayer Play Mode com pelo menos 3 jogadores.
- [ ] Sair andando ou pulando do helicóptero funciona sem teletransporte.
- [ ] As grades seguram quem anda, mas o empurrão joga para fora.
- [ ] Regras puras com testes de Edit Mode.
- [ ] Usuário testou em grupo e aprovou.

## Bugs prováveis

- Tremor porque a posição do veículo e a do jogador são sincronizadas em ritmos diferentes: com o parent em rede, a posição do passageiro viaja relativa ao helicóptero.
- Jogador continuando preso ao veículo depois de sair.
- Piloto preso ao volume da cabine: quem está sentado é ignorado, e o ponto de saída fica fora do volume.
- Pular dentro da cabine soltando o parent: o vínculo é pelo volume da cabine, não pelo chão.
- Passageiro caindo da ilha junto com o helicóptero: o `FallRespawn` dele dispara antes do retorno do helicóptero; o parent sai antes de teleportar.
- Interpolação do Rigidbody brigando com o parent: desligada enquanto o jogador está no helicóptero, como no assento.
- Chão visual inclinado sem bater com o chão físico, que fica reto: pés afundando ou flutuando. Avaliar jogando; se incomodar, diminuir a inclinação.

## Referências

- `CLAUDE.md`: Regras de multiplayer.
- `docs/DECISOES.md`: voo do helicóptero (fase 03).
