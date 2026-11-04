# Fase 01: Primeira pessoa numa ilha flutuante

**Marco:** Protótipo
**Status:** implementada, aguardando teste do usuário

## Objetivo

Andar, olhar e pular em primeira pessoa numa ilha flutuante simples. Cair da beirada leva de volta ao totem.

## Escopo

- Cena de protótipo com uma ilha flutuante em greybox de uns 150 m e o mar lá embaixo. O tamanho real (2 a 3 minutos de ponta a ponta) fica para a fase 19.
- Controle em primeira pessoa pelo Input System: andar, correr, pular e olhar, com teclado e mouse e com controle.
- Personagem com física, que pode ser empurrado (vai importar na fase 02).
- Totem como ponto de renascimento: quem cai da ilha renasce nele depois de 3 segundos (ajustável no Inspector; os 10 s do GDD entram com a morte, na fase 08).
- Valores de movimento em ScriptableObject, ajustáveis no Inspector.
- Remover o `ProjectInfo` provisório e os dois testes de exemplo da fase 00 (feito).
- `SampleScene` apagada e substituída pela `_Project/Scenes/Prototype`; `InputSystem_Actions` movido para `_Project/Data` (feito).

## Fora do escopo

- Rede.
- Vida, morte e reviver completos (fase 08).

## Critérios de pronto

- [ ] Andar, correr, pular e olhar funcionando com teclado e mouse e com controle.
- [x] Cair da ilha leva ao totem.
- [x] Regras puras (por exemplo, quando o jogador conta como caído) com testes de Edit Mode.
- [x] Teste de Play Mode: cair da ilha leva ao totem.
- [ ] Usuário ajustou os valores e aprovou a sensação do movimento.

## Bugs prováveis

- Movimento dependente de frame rate.
- Pulo no ar por checagem de chão mal feita, principalmente em bordas e rampas.
- Personagem grudando em paredes ao pular contra elas, por causa do atrito.
- Cursor do mouse que não trava durante o jogo ou não destrava no menu.

## Referências

- GDD: Mundo; Vida, morte e reviver (totem).
