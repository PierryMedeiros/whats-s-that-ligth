# Fase 00: Setup do projeto

**Marco:** Protótipo
**Status:** pronta para implementar

## Objetivo

Deixar o repositório e o projeto Unity prontos para trabalhar com testes e commits limpos.

## Escopo

- `.gitignore` de Unity, cobrindo também `obj/`, `.vs/`, `.vscode/`, `*.csproj`, `*.sln`, `*.slnx` e builds.
- `.gitattributes` com Git LFS para binários (modelos, texturas, áudio, `.blend`), mantendo os arquivos YAML do Unity como texto.
- Pastas `Assets/_Project/{Scripts,Tests,Prefabs,Scenes,Data,Art,Audio}`.
- Assembly definitions: `ProjetoLuz` em `Scripts`; `ProjetoLuz.Tests.EditMode` e `ProjetoLuz.Tests.PlayMode` em `Tests`.
- Um teste de exemplo de Edit Mode passando.
- Unity CLI confirmada: `unity status` enxerga o editor e os testes rodam por ela.
- Remover o conteúdo de tutorial do template (`TutorialInfo` e `Readme`).

## Fora do escopo

- Qualquer gameplay.
- Instalar o FishNet (fase 02).

## Critérios de pronto

- [ ] `git status` limpo depois do commit, sem arquivos gerados versionados.
- [ ] Binários passando pelo LFS (conferir com `git lfs ls-files` quando entrar o primeiro).
- [ ] Testes de Edit Mode enxergando o assembly `ProjetoLuz` e o teste de exemplo passando pela Unity CLI.
- [ ] Commits sem rastro de IA (`git log --format=full`).

## Bugs prováveis

- Arquivos `.meta` de pastas novas esquecidos fora do commit.
- Assembly de testes de Edit Mode sem a plataforma restrita ao Editor.
- LFS configurado depois de já existir binário commitado, o que exige migração.

## Referências

- `CLAUDE.md`: Código, Testes e Commits.
