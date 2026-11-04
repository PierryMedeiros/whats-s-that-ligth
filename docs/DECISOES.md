# Decisões do projeto

Registro do que foi decidido e por quê. Decisões novas entram no fim, com data. Preços e licenças refletem novembro de 2026.

## 04/11/2026: conceito

- **Jogo curto (cerca de 3h, 5 ilhas).** Escopo viável para um dev solo, com a progressão de ilha em ilha do How to Fish como referência.
- **A luz sempre uma ilha à frente, com a névoa como trava.** Guia o jogador sem mapa e mantém o mistério até o fim. Sem luz, a névoa faz o grupo andar em círculos, o que impede pular ilhas.
- **Twist do peixe-pescador.** Escolhido entre três caminhos (emocionante, cômico e twist). Explica a névoa, a tralha que cai do céu e os desaparecidos.
- **Helicóptero com um piloto só.** Preferido em vez de dividir os controles entre jogadores. Os outros ajudam com conserto, canhão e guincho.
- **1 a 4 jogadores.** Mais fácil de balancear e dá uma função para cada um no helicóptero.
- **Povo fictício.** Dá identidade própria ao jogo e evita caricatura de povos indígenas reais.

## 04/11/2026: tecnologia

- **Unity 6 com C#.** How to Fish e Peak usam Unity, e é o motor com mais tutoriais e assets para co-op com física. O plano Personal é grátis enquanto receita e investimento dos últimos 12 meses ficarem abaixo de US$ 200 mil.
  - Descartado: Godot. É 100% livre e foi usado no Pratfall, mas exige montar multiplayer e ferramentas na mão.
  - Descartado: Unreal. Pesado demais para low-poly e cobra 5% de royalty depois de US$ 1 milhão por produto.
- **Versão 6000.6, que não é LTS.** Instalada no setup e usada no guia oficial da Unity CLI. Atualizar para a 6.7 LTS quando sair.
- **FishNet com FishySteamworks.** Mesma base do How to Fish. Conecta os jogadores em P2P pelo relay da Steam, sem servidor para manter e sem custo por jogador.
  - Descartado: Photon, usado no Peak. Cobra por jogadores simultâneos acima do plano gratuito.
- **Voz pela API do Steamworks.** Sem custo nem serviço extra; o áudio 3D dá a proximidade.
- **Windows nativo, não WSL.** O Unity roda no Windows, e a documentação do Claude Code indica a instalação nativa para projetos Windows. Evita lentidão nos arquivos e problemas de conexão com o editor.
- **Unity CLI em vez de MCP.** A Unity descontinuou o servidor MCP de dentro do editor, e os comandos diretos da CLI são mais rápidos e gastam menos tokens.
- **Steam Direct: US$ 100 por jogo**, devolvidos quando o jogo atinge US$ 1.000 em receita.

## 04/11/2026: arte

- **Low-poly, paleta única e shader cartoon com contorno.** A consistência unifica assets de origens diferentes e evita a cara de IA.
- **Pipeline:** scripts Python no Blender para objetos e cenário; packs CC0 (Kenney, Quaternius) repintados; Meshy no plano gratuito (com crédito obrigatório) para criaturas e bosses.
  - Descartado: TRELLIS 2 rodando local. Pede de 16 a 24 GB de VRAM, e a máquina tem 8 GB.
- **IA declarada na Steam.** Desde janeiro de 2026, só o conteúdo que o jogador consome precisa ser declarado. Código feito com assistente não entra.

## 04/11/2026: processo

- **Protótipo antes de conteúdo.** Primeiro provar que pilotar em grupo é divertido; só depois produzir ilhas, itens e arte.
- **Prazo estimado:** protótipo em cerca de 3 meses e jogo completo em 2 anos ou mais, no ritmo de 5 a 10 horas por semana. O tamanho da versão 1 será decidido depois do protótipo; uma demo com a ilha 1 e o helicóptero é um primeiro lançamento possível.
- **Testes:** regras em C# puro com testes de Edit Mode; Play Mode para comportamentos críticos de cena; sensação e visual se validam jogando.
- **Código:** limpo, sem comentários (só o porquê de contornos de bug), composição e eventos.
- **Commits:** conventional commits em português, atômicos e sem rastro de IA.

## 04/11/2026: sistemas e nomes

- **Comida só recupera vida, sem sistema de fome.** Simples e suficiente para um jogo curto.
- **Reviver:** 5 segundos no corpo, com respiração boca a boca; 10 segundos na estação do helicóptero para quem caiu da ilha. Na ilha 1, o totem da vila faz o papel do helicóptero.
- **Todos mortos reinicia a ilha inteira.** Escolhido em vez de reiniciar só a luta do boss, para manter a tensão. Inventário, baú e carteira não se perdem.
- **Solo renasce sozinho no helicóptero depois de 10 segundos; a ilha só reinicia se morrer na luta do boss.** Sem isso, cada queda no solo zeraria a ilha (o sapo da ilha 2 cospe jogadores para fora).
- **Inventário fixo de 4 espaços.** O que passar disso vai para o baú do helicóptero.
- **Carteira do grupo.** Mais simples de implementar e rende interação no chat de voz.
- **Valores de economia só depois do protótipo.** Só fazem sentido jogando.
- **Título: What's That Light?** Em inglês, porque a maior parte do público da Steam não fala português. Ponto de atenção: muitos jogos têm "Light" no nome, o que atrapalha a busca.
  - Descartado: Junkopter.
  - Descartado: Gambiarra, porque o Gambiarra Garage já tem página na Steam.
- **Povo: Cacarecos. Moeda: botões.**
- **Codinome Projeto Luz no código e na pasta.** Namespaces e assemblies não dependem do título comercial.

## 04/11/2026: save, preço e princípio

- **Save só no PC do host, com o começo da ilha como checkpoint.** Coerente com a regra de reiniciar a ilha: sair no meio funciona igual a todos morrerem, sem perder nada.
- **Perfil local por jogador** guarda os cosméticos.
- **Sem migração de host.** Se o host sai, a partida acaba para todos.
- **Sem save na nuvem e sem cópia da campanha para os convidados.** Simplicidade. O Steam Cloud não teria custo e pode ser ligado depois pelo Auto-Cloud, sem mexer no código.
- **Preço:** decisão para perto do lançamento; a referência do gênero é cerca de US$ 7,99.
- **Princípio do projeto: o básico bem feito.** A solução mais simples que resolve bem, sem nada além do que foi pedido.

## 04/11/2026: fases do projeto

- **Uma fase por arquivo em `docs/fases`, de 00 a 29, com `-DONE` no nome ao concluir.** Basta olhar a pasta para saber o que falta.
- **Fases do protótipo detalhadas; as demais em rascunho.** O protótipo vai mudar o plano, então cada rascunho é refinado quando chegar a vez dele.
- **Skill `implementar-fase`.** Mesmo fluxo em toda sessão: plano antes de código, bugs pensados antes de escrever, o básico bem feito e testes.
- **Fase só fecha depois do teste jogando.** Sensação de jogo não se verifica com teste automatizado.

## 04/11/2026: revisão do workflow

- **Play Mode recarregando domínio e cena.** O template vem com o recarregamento de domínio desligado, o que deixa estado estático sobreviver de um Play para o outro. Com FishNet e Steamworks.NET no projeto, a entrada um pouco mais lenta no Play Mode compensa os bugs evitados. Dá para voltar ao modo rápido depois, com reset explícito dos estáticos.
- **Checagem de trailer depois de cada commit.** Garante o histórico sem rastro de IA mesmo que alguma versão do Claude Code anexe um trailer novo.
