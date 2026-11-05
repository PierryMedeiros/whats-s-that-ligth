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

## 04/11/2026: setup do projeto (fase 00)

- **`.gitkeep` nas pastas de `_Project` ainda vazias.** O git não guarda pasta vazia, mas guarda o `.meta` dela; num clone novo a Unity apagaria o `.meta` órfão e sujaria a árvore. A Unity ignora arquivos que começam com ponto.
- **Testes rodam com `unity command test run`, com o editor aberto.** O `unity test` abre um editor em batch e recusa rodar com o projeto aberto.
- **`ProjectInfo` provisório no assembly `ProjetoLuz`.** Um assembly definition sem script não compila, e o teste de exemplo precisava enxergar o assembly. Sai na fase 01, junto com os testes de exemplo.
- **Play Mode com `EnterPlayModeOptions = None`.** No Unity 6 é essa a configuração que recarrega domínio e cena.

## 04/11/2026: primeira pessoa (fase 01)

- **Personagem com Rigidbody dinâmico, não CharacterController.** Empurrão, knockback (fase 02) e plataforma móvel (fase 04) saem da própria física. O motor controla a velocidade com aceleração no `FixedUpdate`, com atrito zero na cápsula para não grudar em paredes.
- **Superfície acima da inclinação máxima bloqueia o movimento contra ela.** Com atrito zero, empurrar contra uma rampa íngreme fazia a física converter o empurrão em subida.
- **Checagem de chão ignora só o próprio collider, sem layer de jogador.** Assim dá para ficar em pé em cima de outro jogador na fase 02.
- **Ilha greybox de uns 150 m no protótipo.** O objetivo é testar movimento; o tamanho real da ilha 1 fica para a fase 19.
- **Renascimento em 3 s no protótipo.** Os 10 s do GDD pertencem ao sistema de morte da fase 08.
- **Testes de Play Mode rodam de forma assíncrona pela CLI** (`unity command test run --mode all`, depois `test status`), porque entrar no Play Mode recarrega o domínio e derruba a requisição.

## 04/11/2026: multiplayer local (fase 02)

- **FishNet preso na tag `4.7.3`.** A tag `4.7.4` não compila (o transporte Yak veio com código Pro pela metade; issue #1110 no GitHub do FishNet). Subir de versão quando a issue fechar.
- **Início automático da partida.** O editor principal vira host e as instâncias adicionais do Multiplayer Play Mode viram clientes (`CurrentPlayer.IsMainEditor`), com nova tentativa de conexão a cada segundo. Build e solo sobem como host. Zero cliques para testar; o menu de conexão fica para a fase 17.
- **Só o dono simula o próprio jogador.** Input, câmera, AudioListener, motor e queda ficam ligados só no dono; nos outros o Rigidbody é kinematic e segue o `NetworkTransform`. O prefab já nasce no estado de jogador remoto para não existir um frame com duas câmeras.
- **Empurrão pedido pelo dono, validado no servidor e aplicado no dono do alvo** (`ServerRpc` e depois `TargetRpc`). O alvo fica um instante sem controle para a aceleração do motor não anular o knockback.
- **`FallRespawn` encontra o totem ao nascer.** Um prefab de rede não guarda referência de cena; quando houver várias ilhas (fase 15), a ilha atual passa a fornecer o totem.
- **Meshes de greybox com colisão pré-processada.** No Unity 6.6 a colisão pré-processada é ligada em cada mesh, e os meshes embutidos (Cylinder, Sphere) não aceitam a opção; o Inspector avisa que versões futuras não vão mais preparar a colisão sozinhas no build. Os colliders de cena usam cópias em `Art/Meshes` (`GreyboxCylinder`, `GreyboxSphere`) com a opção ligada. Modelos do Blender vão precisar da mesma opção na importação.

## 04/11/2026: voo do helicóptero (fase 03)

- **Voo arcade por controle de velocidade.** Com piloto, o motor leva a velocidade do Rigidbody até o alvo do input, com aceleração separada na horizontal e na vertical, e a gravidade fica desligada (sem input, paira). Sem piloto, a gravidade volta e o helicóptero cai. Rotação X/Z travada: não capota.
- **Inclinação e rotor só visuais, calculados em cada máquina** a partir do movimento do próprio transform. Nada a mais na rede, e passageiros e espectadores veem o mesmo efeito.
- **Piloto preso ao assento pelo parent em rede do FishNet** (`NetworkObject.SetParent` com `Synchronize Parent` no `NetworkTransform` do jogador). A posição viaja relativa ao assento, então o piloto não treme na tela dos outros. É o caminho provável para os passageiros da fase 04.
- **Câmera do jogador relativa à rotação do corpo.** Sentado, o corpo gira com o helicóptero e a câmera vai junto; ao sentar e levantar, o yaw é compensado para a vista não pular.
- **Troca de piloto passa a velocidade junto.** Quem entra recebe a velocidade do servidor por `TargetRpc`; quem sai manda a sua no `ServerRpc`.
- **Helicóptero com `Prevent Despawn On Disconnect`.** Sem isso, o FishNet despawnaria o helicóptero junto com o piloto que caiu da partida; o servidor libera o assento e retoma o ownership.
- **Interact sem a interação Hold do template.** Entrar e sair do assento é um toque, não segurar.
- **No host, o `OnChange` de `SyncVar` do FishNet recebe o valor novo também como anterior.** O assento guarda localmente quem está sentado em vez de confiar no valor anterior.
