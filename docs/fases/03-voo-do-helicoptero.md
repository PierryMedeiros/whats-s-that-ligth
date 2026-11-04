# Fase 03: Voo do helicóptero

**Marco:** Protótipo
**Status:** pronta para implementar

## Objetivo

Um helicóptero em greybox que um jogador consegue pilotar, em solo e em rede.

## Escopo

- Helicóptero de formas primitivas, com física.
- Entrar e sair do assento do piloto pelo botão de interagir.
- O piloto controla direção e altitude, com controle simples e arcade.
- Ownership do helicóptero passa para quem está pilotando.
- Decolar e pousar na ilha.
- Valores de voo em ScriptableObject, ajustáveis no Inspector.

## Fora do escopo

- Passageiros (fase 04).
- Estações de apoio, eventos de voo e upgrades (fase 14).

## Critérios de pronto

- [ ] Um jogador pilota em solo, como host e como cliente.
- [ ] Trocar de piloto não faz o helicóptero pular nem travar.
- [ ] Regras puras do voo com testes de Edit Mode.
- [ ] Usuário ajustou os valores e aprovou a sensação de voo.

## Bugs prováveis

- Tranco na troca de ownership, por estado físico que não foi transferido.
- Helicóptero capotando por centro de massa mal definido.
- Input do piloto sendo lido também pelos outros jogadores.
- Física diferente no host e no cliente.

## Referências

- GDD: Helicóptero.
