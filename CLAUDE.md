# What's That Light? (codinome Projeto Luz)

Co-op em primeira pessoa para PC (Steam), de 1 a 4 jogadores ou solo. Os Cacarecos, nativos de uma ilha flutuante cercada de névoa, montam um helicóptero de gambiarra para seguir uma luz que pisca no horizonte, ilha por ilha. Jogo curto: cerca de 3 horas, 5 ilhas.

- Design completo: `docs/GDD.md`. Leia a seção relevante antes de implementar qualquer mecânica.
- Decisões e motivos: `docs/DECISOES.md`.
- Mudou o design? Atualize o GDD. Surgiu uma decisão técnica? Registre no fim do DECISOES.md, com data e motivo.
- No código vale o codinome: namespaces e assemblies usam `ProjetoLuz`, que não muda se o título comercial mudar.

## O design é um ponto de partida

- O jogo ainda é uma ideia. O GDD e as fases registram o plano de hoje, não uma especificação fechada, e vão mudar bastante com o que se descobrir jogando.
- Se algo no design parecer ruim, inviável ou em conflito com o que já foi feito, aponte e sugira alternativa em vez de seguir à risca.
- Toda decisão nova pode afetar o que já estava planejado. Ao decidir algo, confira se contradiz o GDD ou alguma fase futura e avise o usuário. Ao fechar uma fase, revise as fases seguintes (a skill `implementar-fase` detalha como).

## Princípio: o básico bem feito

- Prefira sempre a solução mais simples que resolve bem o problema.
- Nada de feature, abstração, configuração ou dependência que não foi pedida. Se algo extra parecer útil, sugira antes de fazer.
- Poucas coisas funcionando muito bem valem mais que muitas pela metade.

## Fases

- O plano do jogo inteiro está em `docs/fases/`, um arquivo por fase, em ordem (de `00-...` a `29-...`).
- A fase atual é o primeiro arquivo sem `-DONE` no nome.
- Para implementar qualquer fase, siga a skill `implementar-fase`.
- Uma fase só ganha `-DONE` no nome depois de o usuário testar jogando e aprovar.
- Fases em rascunho são refinadas com o usuário antes de começar.
- Marco atual: protótipo (fases 00 a 07), para provar que pilotar o helicóptero em grupo é divertido. Tudo em greybox.

## Stack

- Unity 6 (6000.6) com URP, scripts em C#. Desenvolvimento no Windows nativo (projeto no disco do Windows, não no WSL).
- Rede: FishNet. Transporte Tugboat nos testes locais; FishySteamworks (P2P pelo relay da Steam) no online.
- Steam: Steamworks.NET. Usar o App ID 480 (Spacewar) até termos um App ID próprio.
- Voz: API de voz do Steamworks (`SteamUser.StartVoiceRecording`, `GetVoice`, `DecompressVoice`), enviada pelo FishNet e tocada num `AudioSource` 3D na cabeça de cada jogador.
- Testes locais com vários jogadores: Multiplayer Play Mode, com Tugboat. A Steam não conecta duas builds no mesmo PC.
- Controle do editor: Unity CLI com o pacote Pipeline (`unity command`, `unity eval`, testes; `unity --help` lista tudo). O editor precisa estar aberto.
- Testes: Unity Test Framework (NUnit).
- 3D: Blender. Modelos simples são gerados por script Python (`bpy`) sempre que possível.

## Regras de multiplayer

- Toda feature nasce em rede. Nada de fazer single-player para adaptar depois.
- Solo é um host sem clientes, pelo mesmo caminho de código.
- O host é o servidor. Estado de jogo (dinheiro, itens, baú, progresso, missões, bosses, luz) só muda no servidor; clientes pedem via `ServerRpc`.
- O movimento do próprio jogador tem autoridade do cliente: é co-op, então responsividade vale mais que anti-cheat.
- Quem controla um objeto físico (por exemplo, o piloto do helicóptero) recebe o ownership dele.
- Jogadores dentro do helicóptero acompanham o veículo como plataforma móvel; nunca depender só de atrito da física.
- Sincronizar o mínimo necessário. Nada de RPC a cada frame sem motivo.

## Código

- Código limpo: nomes descritivos, métodos curtos, uma responsabilidade por classe, early return em vez de `if` aninhado.
- Sem comentários: o código se explica pelos nomes. Única exceção: um porquê que o código não consegue mostrar, como o contorno de um bug da Unity ou do FishNet.
- Identificadores em inglês, com namespaces por domínio (`ProjetoLuz.Player`, `ProjetoLuz.Helicopter` etc.).
- `PascalCase` para tipos, métodos e propriedades; `_camelCase` para campos privados; `[SerializeField] private` em vez de campo público; `readonly` sempre que der.
- Uma classe por arquivo, com o mesmo nome do arquivo.
- Composição em vez de herança. Dependências entram por referência serializada ou por construtor. Evite singletons e estado estático global; as APIs estáticas do FishNet, como `InstanceFinder`, são a exceção.
- Sistemas conversam por eventos C#, não checando estado a cada frame.
- Valores de ajuste (física, controles, itens, bosses, economia) ficam em ScriptableObjects ou expostos no Inspector, nunca como números mágicos. Física e controles serão ajustados à mão.
- Desempenho: nada de `Find`, `GetComponent`, LINQ ou alocação de memória dentro de `Update`; prefira `TryGetComponent` e `CompareTag`.
- Input sempre pelo Input System, nunca pela classe `Input` antiga.
- Nada de código morto, código comentado ou `Debug.Log` esquecido.
- Pastas: `Assets/_Project/{Scripts,Tests,Prefabs,Scenes,Data,Art,Audio}`. Scripts organizados por domínio: `Player`, `Helicopter`, `Networking`, `Items`, `Islands`, `Voice`, `UI`.

## Testes

- Regras de jogo moram em classes C# puras, fora de MonoBehaviour e NetworkBehaviour, e toda regra nova nasce com testes de Edit Mode. Exemplos: baú e empilhamento, economia, progressão da luz, missões, dano e knockback, save.
- MonoBehaviours e NetworkBehaviours são finos: leem input ou rede, chamam a regra pura e aplicam o resultado na cena.
- Comportamento crítico de cena ganha teste de Play Mode (por exemplo: cair da ilha leva ao totem).
- Bug de lógica: primeiro um teste que reproduz o bug, depois a correção.
- Não escreva teste para sensação de jogo, ajuste de física, visual ou layout de UI. Isso se valida jogando.
- Assemblies: código do jogo no assembly definition `ProjetoLuz`, em `Assets/_Project/Scripts`; testes em `ProjetoLuz.Tests.EditMode` e `ProjetoLuz.Tests.PlayMode`, em `Assets/_Project/Tests`.

## Fluxo de trabalho

- Comece cada sessão com a árvore git limpa.
- Depois de alterar scripts: espere compilar, leia o console, rode os testes e corrija tudo antes de seguir.
- Mudanças pequenas e incrementais. Ao terminar, diga o que testar jogando no editor.
- Não edite `.meta`, `Library/`, `ProjectSettings/` nem `Packages/manifest.json` sem pedir.
- Não apague nem mova assets sem confirmar.

## Commits

- Conventional commits em português: `tipo(escopo): descrição`, no imperativo, em minúscula, sem ponto final, com até 72 caracteres.
- Tipos: `feat`, `fix`, `test`, `refactor`, `docs`, `chore`, `perf`. Escopos: `player`, `heli`, `net`, `steam`, `voice`, `items`, `islands`, `ui`, `art`, `audio`, `tools` (omita quando a mudança for transversal).
- Commits atômicos: uma mudança lógica por commit. `git add` por caminho e `git diff --staged` revisado antes de cada commit.
- Commit só com o projeto compilando sem erros e todos os testes passando.
- Nenhum rastro de IA no histórico: sem `Co-Authored-By`, sem "Generated with" e sem menção a IA nas mensagens de commit.
- Nunca commitar `Library/`, `Temp/`, `Logs/`, `UserSettings/`, `obj/`, `.vs/`, `.vscode/`, arquivos de solução gerados (`*.csproj`, `*.sln`, `*.slnx`), builds ou segredos.
