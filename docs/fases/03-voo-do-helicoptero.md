# Fase 03: Voo do helicóptero

**Marco:** Protótipo
**Status:** em andamento

## Objetivo

Um helicóptero em greybox que um jogador consegue pilotar, em solo e em rede.

## Escopo

- Helicóptero de formas primitivas, com física: cabine aberta, esquis, rotor e cauda.
- Entrar e sair do assento do piloto pelo botão de interagir (E, Y no controle), mirando o assento.
- O piloto controla direção e altitude, com controle simples e arcade: W/S para frente e para trás, A/D giram, Pulo sobe, Agachar (C, B no controle) desce. A câmera continua livre no mouse.
- Ownership do helicóptero passa para quem está pilotando; sem piloto, fica com o servidor e o helicóptero cai pela gravidade.
- O piloto acompanha o assento pelo parent em rede do FishNet (posição relativa ao helicóptero).
- Inclinação visual num filho, para onde o helicóptero acelera e gira, e rotor girando com o motor ligado. Só visual, calculado em cada máquina.
- Decolar e pousar na ilha. Se o helicóptero cair da ilha, volta ao ponto de pouso.
- Valores de voo e do visual em ScriptableObject, ajustáveis no Inspector.

## Fora do escopo

- Passageiros (fase 04).
- Pairar sozinho para o solo, estações de apoio, eventos de voo e upgrades (fase 14).
- Dano, combustível, som e modelo de verdade.

## Critérios de pronto

- [ ] Um jogador pilota em solo, como host e como cliente.
- [ ] Trocar de piloto não faz o helicóptero pular nem travar.
- [ ] O piloto não treme na tela dos outros jogadores.
- [ ] Inclinação e rotor visíveis para todos.
- [ ] Regras puras do voo com testes de Edit Mode.
- [ ] Usuário ajustou os valores e aprovou a sensação de voo.

## Bugs prováveis

- Tranco na troca de ownership, por estado físico que não foi transferido: quem sai manda a velocidade junto; quem entra recebe a velocidade do servidor.
- Helicóptero capotando por centro de massa mal definido: rotação X/Z travada no Rigidbody; a inclinação é só visual.
- Input do piloto sendo lido também pelos outros jogadores: o voo só lê o input do piloto local.
- Física diferente no host e no cliente: só quem controla simula; nos outros o corpo é kinematic.
- Piloto desconectando no ar: o servidor libera o assento e retoma o ownership, sem despawnar o helicóptero.
- Dois jogadores entrando ao mesmo tempo: o servidor decide.
- Cápsula do piloto empurrando o helicóptero por dentro: collider do jogador desligado enquanto está sentado.

## Referências

- GDD: Helicóptero.
