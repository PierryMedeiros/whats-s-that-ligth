# Fase 08: Vida, morte e reviver

**Marco:** Sistemas
**Status:** rascunho. Refine com o usuário antes de começar (escopo, critérios de pronto e bugs prováveis).

## Objetivo

Dar ao jogador vida, morte e as duas formas de reviver, com as regras de reinício da ilha.

## Escopo inicial

- Vida e dano; o corpo fica onde o jogador morreu.
- Reviver no corpo (5 segundos, com respiração boca a boca) e na estação do helicóptero (10 segundos); na ilha 1, o totem faz esse papel.
- Todos mortos reinicia a ilha; regra própria do solo.
- Itens do inventário nunca se perdem; o objeto que estava nas mãos cai onde o jogador morreu.
- O `FallRespawn` do protótipo (congela e renasce no totem em 3 s) vira parte desse sistema: cair da ilha passa a ser morte, com os 10 s do GDD no solo.

## Referências

- GDD: Vida, morte e reviver.
