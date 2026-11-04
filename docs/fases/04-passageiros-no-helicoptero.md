# Fase 04: Passageiros no helicóptero

**Marco:** Protótipo
**Status:** pronta para implementar

## Objetivo

Os outros jogadores ficam em pé dentro do helicóptero em movimento, estáveis, em rede. É a parte mais difícil do protótipo.

## Escopo

- Quem está dentro do helicóptero acompanha o veículo como plataforma móvel.
- Entrar e sair andando, inclusive pulando do helicóptero em voo.
- Até 4 jogadores: um piloto e três passageiros.
- O `PlayerMotor` define a velocidade no chão em valor absoluto; ela precisa passar a ser relativa à velocidade do Rigidbody que está embaixo (a checagem de chão já sabe qual collider é).

## Fora do escopo

- Estações de apoio: conserto, canhão, guincho e reviver (fase 14).

## Critérios de pronto

- [ ] Passageiros não tremem, não atravessam o chão e não escorregam em voo, curva e subida.
- [ ] Funciona para host e clientes, testado no Multiplayer Play Mode com pelo menos 3 jogadores.
- [ ] Sair andando ou pulando do helicóptero funciona sem teletransporte.
- [ ] Usuário testou em grupo e aprovou.

## Bugs prováveis

- Tremor porque a posição do veículo e a do jogador são sincronizadas em ritmos diferentes.
- Jogador ficando para trás quando o helicóptero acelera, porque o motor ignora a velocidade do chão.
- Jogador continuando preso ao veículo depois de sair.
- Interpolação de rede brigando com o movimento relativo ao veículo.

## Referências

- `CLAUDE.md`: Regras de multiplayer.
