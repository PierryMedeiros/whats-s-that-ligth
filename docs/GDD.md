# GDD: What's That Light?

Codinome do projeto: Projeto Luz. Documento vivo: atualize quando uma decisão mudar. Tudo aqui é o plano atual, não uma especificação fechada; o design vai mudar conforme o jogo for testado.

## Visão geral

- **Título:** What's That Light?
- **Gênero:** aventura co-op em primeira pessoa, com física cômica.
- **Jogadores:** 1 a 4 (online pela Steam) ou solo.
- **Plataforma:** PC Windows na Steam; Steam Deck e Linux via Proton.
- **Duração:** cerca de 3 horas, 5 ilhas.
- **Pitch:** os Cacarecos, nativos de uma ilha flutuante, montam um helicóptero de gambiarra com a tralha que cai do céu para descobrir o que é a luz que pisca no horizonte.
- **Referências:** How to Fish (progressão de ilha em ilha), Peak e Pratfall (física cômica e co-op com voz por proximidade).

## Pilares

1. Física que gera comédia: quedas, empurrões, objetos desajeitados.
2. Co-op com voz por proximidade: a graça está na conversa e na confusão do grupo.
3. O mistério da luz puxa o jogador até o fim.
4. Gambiarra: tudo no mundo é feito de tralha reaproveitada.

## Mundo

- Arquipélago de ilhas flutuantes sobre o mar, escondidas por uma névoa densa.
- Cada ilha pode ser atravessada em 2 a 3 minutos.
- De tempos em tempos cai tralha do céu (panela, ventilador, cone de trânsito, pato de borracha). O povo da ilha vive disso: casas, ferramentas e roupas são gambiarras feitas com esses "presentes do céu".
- O protagonista é um Cacareco, povo fictício da ilha natal, com cultura própria (língua inventada, rituais, roupas de gambiarra). Não se inspirar diretamente em povos indígenas reais.

## A luz

- Da ilha natal, o protagonista vê uma luz piscando atrás da névoa. Para ele, a ilha é o mundo inteiro.
- A luz está sempre uma ilha à frente. Quando o grupo chega, ela já sumiu e só restam rastros dela.
- A próxima luz só acende depois que o boss da ilha atual é derrotado.
- Sem uma luz para seguir, a névoa faz o grupo andar em círculos e sair de volta na ilha de onde partiu (um NPC ri do grupo toda vez). É isso que impede pular ilhas.

### O twist

A luz é a isca de um peixe-pescador gigante escondido nas nuvens.

- A névoa é o esconderijo dele.
- Ele só move a isca depois do boss porque não quer presa pequena. É o How to Fish ao contrário: lá você evolui para pescar peixe maior; aqui o peixe espera você evoluir para te pescar.
- A tralha que cai do céu é o que ele engole e não consegue digerir.
- Quem seguiu a luz e nunca voltou foi engolido.

### Pistas (surpresa na primeira vez, óbvio olhando para trás)

- Ilha 1: a vila conta a lenda de quem seguiu a luz e sumiu. O inventor monta o helicóptero para ir atrás do irmão, que foi um deles. Easter egg: a silhueta do peixe na névoa, visível só num momento específico.
- Ilha 2: o acampamento abandonado desse grupo, com desenhos da luz mudando de lugar. Um morador comenta que todo bicho cai numa isca que brilha.
- Ilha 3: um dente do tamanho de uma casa preso no gelo, que o povo usa como escorregador.
- Ilha 4: as pipas que chegam perto da luz nunca voltam. Quando a enguia cai, um relâmpago enorme ilumina a silhueta gigante por um segundo, e logo depois a luz acende bem naquela direção.
- Todas: a gosma brilhante que a luz deixa para trás é baba da isca.

## Estrutura das ilhas

Loop de cada ilha:

1. Chegar e conhecer o povo local e o problema deles.
2. Explorar, coletar tralha, vender ao mercador e comprar upgrades.
3. Resolver o problema do povo, o que libera o ritual do boss.
4. Invocar o boss quando o grupo se sentir pronto.
5. Vencer o boss acende a próxima luz.

Padrão de todas as ilhas:

- A missão do povo sempre constrói a invocação do boss (uma isca, uma fogueira, uma pipa), então o grupo escolhe a hora da luta.
- A mecânica nova da ilha aparece na exploração, na missão e no boss.
- Uma gosma brilhante marca onde a luz esteve. Dá para coletar e usar como lanterna.
- Cada povo explica a luz de um jeito diferente.
- O mercador é o mesmo em todas as ilhas e sempre chega antes do grupo, sem ninguém saber como.

| # | Ilha | Mecânica própria | Boss |
|---|------|------------------|------|
| 1 | Natal (tropical) | tutorial e montagem do helicóptero | caranguejo-ermitão gigante que usa um carro como concha |
| 2 | Cogumelos | cogumelos que funcionam como trampolim | sapo gigante que engole jogadores e cospe para fora da ilha |
| 3 | Gelada | o frio drena vida longe do calor; gelo escorregadio | golem feito de geladeiras |
| 4 | Tempestade | vento empurrando todo mundo | enguia elétrica, enfrentada de dentro do helicóptero |
| 5 | A luz | a ilha é a cabeça do peixe | peixe-pescador gigante |

### Ilha 1: montar o helicóptero

O inventor da vila passou a vida montando um helicóptero com tralha, mas faltam quatro peças. Cada uma ensina um sistema:

- Hélice (pá de ventilador gigante) no alto de um penhasco: exploração.
- Cabine (banheira pesada), bem mais rápida de carregar em dupla: física.
- Combustível, vendido pelo mercador: economia.
- Motor, dentro do carro que o caranguejo-ermitão usa como concha: boss.

### Ilha 2: Cogumelos

- **Povo:** vive pulando de cogumelo em cogumelo e acha andar no chão falta de educação. Para eles, a luz era um vagalume sagrado.
- **Problema:** um sapo gigante pega com a língua tudo que pula alto. O povo está preso no chão, morrendo de vergonha.
- **Missão:** montar uma mosca-isca de gambiarra (asas de sacola, corpo de lata, barbeador elétrico para o zumbido). Os trampolins levam até as peças; uma delas está no acampamento abandonado dos exploradores.
- **Boss:** a língua engole jogadores e cospe para fora da ilha. Quando ela gruda na isca ou em tralha pesada, o sapo fica exposto e o grupo usa os trampolins para cair na cabeça dele. Na fase final ele infla e vira um trampolim gigante: cada pulo do grupo empurra o sapo para mais perto da beirada, até ele cair da ilha.

### Ilha 3: Gelada

- **Povo:** mora dentro de geladeiras que caíram do céu, porque elas isolam bem o frio. Batem os dentes o tempo todo, e a língua deles é feita disso. Para eles, a luz era um sol pequeno que veio visitar.
- **Problema:** o golem está roubando as geladeiras-casas para montar o próprio corpo. O povo sobrou em volta da última fogueira.
- **Missão:** acender a Fogueira Grande do outro lado da ilha, levando uma panela de brasa pelo gelo. Quem se afasta da brasa congela, então o grupo anda grudado em quem carrega; um escorregão pode apagar tudo.
- **Boss:** a fogueira acesa atrai o golem, que vem apagá-la. Cada pisão dele faz o grupo deslizar no gelo rumo à beirada. Levar brasa às juntas de gelo solta as geladeiras uma a uma; o golpe final é jogar a brasa no congelador que serve de cabeça.

### Ilha 4: Tempestade

- **Povo:** empina pipas de tralha para capturar a energia dos raios que mantém a vila acesa. Para eles, a luz é a mãe dos raios.
- **Problema:** uma enguia elétrica nas nuvens está comendo os raios, e a vila ficou no escuro.
- **Missão:** montar uma pipa gigante (lona, varetas, rabiola de sacolas), instalar um para-raios no helicóptero e empinar a pipa no ponto mais alto. O mesmo vento que empurra todo mundo para a beirada levanta a pipa. O grupo inteiro segura a linha: se alguém solta, quem fica é arrastado. No solo, a linha vai amarrada numa âncora.
- **Boss (no ar):** a enguia ataca o helicóptero com descargas. O piloto desvia, o canhão atira tralha e quem conserta apaga os curtos. O golpe final é enrolar a enguia na linha da pipa, voando em círculos, até ela despencar.

### Ilha 5 e final

- Pela primeira vez, a luz não some quando o grupo chega. O chão é quente, tudo parece respirar e a luz fica no alto de uma "árvore" no centro.
- Quando o grupo alcança a luz, a árvore se ergue: é a haste da isca, e a ilha inteira é a cabeça do peixe.
- Luta final em três fases:
  1. Em cima dele: ele se sacode para jogar todo mundo longe.
  2. Na barriga: ele engole o grupo junto com o helicóptero. Lá dentro estão os desaparecidos, inclusive o irmão do inventor, vivendo numa vila de gambiarra feita com a tralha engolida. O mercador também já está lá, com a loja montada. Os desaparecidos ajudam a consertar o helicóptero e o grupo sai voando pela boca do peixe.
  3. No ar: o golpe final é fisgar a isca com o guincho e arrancar. Pela primeira vez no jogo, quem pesca é você.
- Final: a névoa se dissipa e aparece o arquipélago inteiro, com muito mais ilhas do que se imaginava. A isca vira o farol da vila.
- Pós-créditos: uma nova luz pisca no horizonte (gancho para atualização ou continuação).

## Helicóptero

- Montado com tralha na ilha 1 (ventilador de teto vira rotor, banheira vira cabine).
- Um piloto controla direção e altitude.
- Os outros jogadores ajudam durante o voo:
  - Consertar: ele se desmonta no caminho e precisa de silver tape.
  - Canhão de tralha: defender de bichos voadores.
  - Guincho: pegar coisas no ar; decisivo nas lutas das ilhas 4 e 5.
- Estação de reviver: traz de volta quem caiu da ilha (ver Vida, morte e reviver).
- Solo: alavanca de pairar para largar o manche e resolver as coisas; eventos mais leves.
- Viagens entre ilhas têm eventos (rajadas de vento, bichos voadores, tralha caindo para pegar no guincho).
- Baú lateral: guarda qualquer item; itens iguais empilham com contador. A capacidade aumenta com upgrade.

## Vida, morte e reviver

- O jogador tem vida. Perde vida com ataques e com o frio da ilha 3. Cair da ilha mata.
- Comida recupera vida. Não existe sistema de fome.
- Ao morrer, o corpo fica onde caiu. Os itens do inventário nunca se perdem; o objeto grande que estava nas mãos cai ali mesmo (se foi no mar, já era).
- Reviver no corpo: segurar o botão de interagir (F no teclado) por 5 segundos ao lado do corpo, com uma respiração boca a boca exagerada.
- Reviver no helicóptero: para quem caiu da ilha ou morreu num lugar inacessível, segurar interagir por 10 segundos na estação de reviver. Na ilha 1, antes de o helicóptero existir, essa estação é o totem da vila.
- Soltar o botão zera o contador.
- Todos mortos: a ilha inteira reinicia do começo. O grupo volta ao ponto de partida da ilha, e a missão, o boss e o mundo da ilha voltam ao estado inicial. Inventário, baú e carteira continuam.
- Solo: o jogador renasce sozinho no helicóptero (no totem, na ilha 1) depois de 10 segundos. Se morrer durante a luta do boss, a ilha reinicia.

## Combate

- Baseado em empurrar: armas de gambiarra com knockback contra criaturas que tentam jogar o grupo para fora. A beirada é a maior ameaça, para os dois lados.
- Objetos pesados ficam bem mais fáceis de carregar em dupla.

## Itens

### Inventário

- 4 espaços por jogador, sem mochila maior. Para levar mais, guarde no baú do helicóptero.
- Objetos grandes (banheira, TV) não entram no inventário: vão nas mãos, um por vez.

### Úteis

- Ferramentas e armas, todas de empurrar:
  - Frigideira: a inicial, com empurrão curto.
  - Estilingue: atira tralha pequena como munição.
  - Desentupidor: puxa inimigos e objetos, e salva amigo na beirada.
  - Soprador de folhas: empurra em área, sem parar.
  - Luva de boxe com mola: o empurrão mais forte, mas lenta para recarregar.
- Consumíveis: silver tape (conserta o helicóptero), pimenta (esquenta no frio) e gosma brilhante (ilumina).
- Guarda-chuva: plana ao cair e vira asa-delta no vento da ilha 4.
- Rádio: permite falar com quem está longe.

### Comida (só recupera vida)

- Banana: recupera pouco, e a casca vira armadilha.
- Coco: recupera bastante, mas precisa ser quebrado antes (a frigideira resolve).
- Enlatados que caem do céu: recuperam bem.
- Bolo de aniversário: raro; cura todo mundo em volta quando alguém corta.

### Engraçados

- Casca de banana: armadilha, inclusive para os amigos.
- Megafone (aumenta o alcance da voz), buzina e pato de borracha que grita.

### Cosméticos

- Cone de trânsito, óculos de natação e outros, na loja e em segredos.
- Um por boss: chapéu de sapo, balde de gelo e antena que solta faísca.

### Inúteis

- A chave sem porta abre um baú escondido na barriga do peixe.
- O controle remoto nunca faz nada, e todo mundo vai testar mesmo assim. Nem o mercador compra, mesmo ele sendo cheio de botões.

### Fontes

- Chuvas de tralha aleatórias, baús escondidos, drops de boss, recompensas de missão e a loja do mercador.

## Economia

- A moeda são botões, numa carteira do grupo: todo mundo vende para a mesma conta e qualquer um gasta. É mais simples de implementar e rende discussão no chat de voz.
- Entrada: venda de tralha ao mercador, recompensas de missão, baús escondidos e drops de boss.
- Tralha frágil (TV, abajur, vaso) vale mais, mas perde valor a cada pancada.
- Regra de ouro: dá para comprar o essencial de cada ilha sem farmar; o resto é bônus para quem explora.
- Loja: estoque fixo mais um estoque da ilha, com o que ajuda no desafio dela (bota de mola nos Cogumelos; pimenta e cachecol na Gelada; âncora e bota pesada na Tempestade).
- Upgrades do helicóptero: motor, remendos (quebra menos no voo), baú maior, guincho mais comprido e canhão mais rápido. O para-raios vem da missão da ilha 4.
- Gastos: compras, tralha quebrada, objetos grandes perdidos no mar e o canhão do helicóptero, que usa tralha como munição (atirar ou vender vira uma escolha).
- Preços em faixas: consumível barato, ferramenta média, upgrade do helicóptero caro e cosmético raro como luxo. Os valores reais saem do protótipo.
- Progressão principal: a sequência de ilhas, liberada pela luz.

## Progresso e save

- A campanha fica salva só no PC do host: ilha atual, upgrades do helicóptero, baú e carteira de botões. São 3 espaços de campanha.
- O perfil fica no PC de cada jogador e guarda os cosméticos desbloqueados, que valem em qualquer campanha, inclusive na de amigos. Cosmético comprado na loja fica com quem comprou; o de boss vai para todo mundo que estava na luta.
- A ilha atual é salva ao chegar nela; baú, carteira e upgrades são salvos o tempo todo.
- Sair no meio da ilha funciona igual a todos morrerem: na volta, o grupo começa a ilha do zero, sem perder nada.
- Ao sair, o que estava nos bolsos vai para o baú, e cada jogador volta com a frigideira e os bolsos vazios. Assim o save não depende de quem está jogando.
- Amigos entram a qualquer momento, nascendo no helicóptero (ou no totem, na ilha 1). Quem sai deixa os itens no baú.
- Se o host sai, a partida acaba para todos (sem migração de host).
- Depois de zerar, dá para voltar a qualquer ilha para caçar segredos e cosméticos.
- Fora do escopo, por simplicidade: save na nuvem e cópia da campanha para os convidados.

## Voz por proximidade

- O volume cai com a distância (áudio 3D na cabeça do personagem).
- Megafone aumenta o alcance da voz.
- Rádio permite falar com quem está longe, do outro lado da ilha, por exemplo.
- Dentro do helicóptero, o barulho do rotor abafa as vozes.

## Direção de arte

- Low-poly, cores chapadas de uma única paleta e o mesmo shader cartoon com contorno em tudo. A consistência é o que evita a cara de IA.
- Personagens bobinhos, de formas simples, com física de ragdoll.
- Pipeline:
  - Objetos e cenário: scripts Python que geram os modelos no Blender.
  - Packs CC0 (Kenney, Quaternius) repintados com a paleta.
  - Criaturas e bosses: base gerada no Meshy (plano gratuito, licença CC BY: creditar o Meshy), depois simplificada e repintada no Blender.
- Steam: declarar na pesquisa de conteúdo todo asset gerado com IA que vá para o jogo ou para a página da loja. Assistente de código não entra na declaração.

## Escopo e marcos

- Protótipo: cerca de 3 meses com 5 a 10h por semana (fases 00 a 07 em `docs/fases`).
- Depois do protótipo: definir o tamanho da versão 1.
- Primeiro lançamento possível: demo com a ilha 1 e o helicóptero.

## Em aberto

- Valores de preços e balanceamento (depois do protótipo).
- Escala de dificuldade conforme o número de jogadores (testar no protótipo).
- Preço do jogo: decisão para perto do lançamento (referência do gênero: cerca de US$ 7,99).
