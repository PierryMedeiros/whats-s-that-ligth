# Fase 00: Setup do projeto

**Marco:** Protótipo
**Status:** implementada, aguardando teste do usuário

## Objetivo

Deixar o repositório e o projeto Unity prontos para trabalhar com testes e commits limpos.

## Escopo

- `.gitignore`: o atual já cobre o essencial; acrescentar `CLAUDE.local.md`.
- `.gitattributes` com `* text=auto` para normalizar o fim de linha e Git LFS para binários (modelos, texturas, áudio, `.blend`), mantendo os arquivos YAML do Unity como texto.
- Pastas `Assets/_Project/{Scripts,Tests,Prefabs,Scenes,Data,Art,Audio}`.
- Assembly definitions: `ProjetoLuz` em `Scripts`; `ProjetoLuz.Tests.EditMode` e `ProjetoLuz.Tests.PlayMode` em `Tests`.
- Um teste de exemplo de Edit Mode passando.
- Unity CLI confirmada: `unity status` enxerga o editor e os testes rodam por ela.
- Remover o conteúdo de tutorial do template (`TutorialInfo` e `Readme`).
- Declarar o `com.unity.test-framework` direto no `Packages/manifest.json` (hoje ele só chega como dependência de outros pacotes).
- Remover o pacote `com.unity.collab-proxy` (Unity Version Control), já que o projeto usa Git.
- Instalar as skills da Unity para o Claude Code (`unity skill install`; o nome do agente aparece no `--help`).
- Play Mode recarregando domínio e cena (Project Settings > Editor > Enter Play Mode Settings), para que estado estático não sobreviva de um Play para o outro.

## Fora do escopo

- Qualquer gameplay.
- Instalar o FishNet (fase 02).
- Reescrever o histórico do git. O único binário já commitado fora do LFS é o `URP.png` do tutorial, que sai junto com o `TutorialInfo`.

## Critérios de pronto

- [x] `git status` limpo depois do commit, sem arquivos gerados versionados.
- [x] Regras do LFS configuradas: `git check-attr` confirma o filtro `lfs` em `.png` e `.blend` e o `text` em `.unity`. A conferência com `git lfs ls-files` foi para a fase 18, quando entra o primeiro binário.
- [x] Testes de Edit Mode enxergando o assembly `ProjetoLuz` e o teste de exemplo passando pela Unity CLI.
- [x] Commits sem rastro de IA (`git log --format=full`).
- [x] Play Mode recarregando domínio e cena.

## Bugs prováveis

- Arquivos `.meta` de pastas novas esquecidos fora do commit.
- Assembly de testes de Edit Mode sem a plataforma restrita ao Editor.
- Arquivos já versionados com fim de linha misturado depois do `* text=auto` (renormalizar com `git add --renormalize .`, num commit próprio).

## Referências

- `CLAUDE.md`: Código, Testes e Commits.
