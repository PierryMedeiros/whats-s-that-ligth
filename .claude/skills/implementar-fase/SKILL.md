---
name: implementar-fase
description: Fluxo obrigatório para implementar, começar, continuar ou retomar uma fase do projeto em docs/fases. Use sempre que o usuário pedir para trabalhar numa fase, mesmo com pedidos curtos como "bora pra próxima fase", "faz a fase 3", "continua de onde parou" ou "o que falta?". Garante plano antes de código, bugs pensados antes de escrever, boas práticas e o básico bem feito.
---

# Implementar uma fase

Este projeto é construído uma fase por vez. Cada fase está em `docs/fases/`, e o arquivo com `-DONE` no nome já foi concluído. O objetivo é fazer cada fase com o básico bem feito: a solução mais simples que funciona bem, testada e sem surpresas para o usuário.

## 1. Descobrir a fase

- Use a fase que o usuário pediu. Se ele não disse qual, use a primeira sem `-DONE`.
- Leia o arquivo da fase inteiro e as seções do `docs/GDD.md` citadas nele. Consulte o `docs/DECISOES.md` quando a fase tocar em algo já decidido.
- Se a fase estiver em rascunho, não implemente ainda: proponha ao usuário escopo, critérios de pronto e bugs prováveis, espere a aprovação e atualize o arquivo da fase com o que for combinado.
- Se a fase anterior não estiver concluída, avise antes de começar.

## 2. Conferir o terreno

- A árvore git precisa estar limpa. Se não estiver, pergunte ao usuário o que fazer antes de mexer.
- Se a fase já foi começada em outra sessão, use os critérios marcados e o histórico do git para continuar de onde parou.

## 3. Plano antes de código

Mostre um plano curto e espere a aprovação do usuário:

- O que vai ser feito, em passos pequenos.
- Arquivos que serão criados ou alterados.
- Regras de jogo que viram classes C# puras e os testes de cada uma.
- Bugs prováveis e como evitar cada um.
- O que fica de fora, para o escopo não crescer.

## 4. Pensar nos bugs antes de escrever

Além dos bugs listados na fase, revise sempre:

- Autoridade: quem pode mudar esse estado, o servidor ou o dono? Cliente nunca muda estado de jogo direto.
- Host, cliente e solo: a mesma coisa funciona nos três?
- Quem entra depois recebe o estado atual, e quem sai no meio não deixa nada quebrado.
- Física em `FixedUpdate` e nada dependente de frame rate.
- Ordem de inicialização: referências prontas antes do uso, sem nulos.
- Toda inscrição em evento tem a desinscrição correspondente.
- Interações que podem disparar duas vezes, como dois jogadores pegando o mesmo item ao mesmo tempo.
- Valores extremos: zero, negativo, cheio e vazio.

## 5. Implementar

- Siga as seções Princípio, Código, Testes e Regras de multiplayer do `CLAUDE.md`.
- Faça a menor implementação que atende os critérios de pronto. Se algo extra parecer útil, sugira; não faça.
- Escreva as regras de jogo primeiro, com os testes de Edit Mode junto. Depois, o componente fino que liga a regra à cena.
- Faça commits atômicos ao longo do trabalho, seguindo a seção Commits do `CLAUDE.md`.

## 6. Verificar

- Compile e leia o console até não sobrar erro nem aviso novo.
- Rode todos os testes pela Unity CLI até tudo passar.
- Marque no arquivo da fase os critérios atendidos.
- Passe ao usuário um roteiro curto do que testar jogando: solo, host e cliente (Multiplayer Play Mode), e o que observar em cada um.

## 7. Fechar a fase

Só depois de o usuário confirmar que testou jogando e aprovou:

- Atualize o GDD ou o DECISOES.md se algo mudou durante a fase.
- Revise as fases futuras à luz do que foi decidido e implementado nesta: leia os arquivos seguintes em `docs/fases/` e procure o que ficou contraditório, obsoleto, mais fácil ou mais difícil. Mostre ao usuário a lista do que precisa mudar em cada fase afetada e aplique só os ajustes aprovados. Se nada foi afetado, diga isso.
- Renomeie o arquivo da fase com `git mv`, acrescentando `-DONE` antes do `.md`, e faça o commit `docs: conclui fase NN`.
- Diga qual é a próxima fase e se ela está em rascunho.
