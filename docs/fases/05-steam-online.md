# Fase 05: Steam online

**Marco:** Protótipo
**Status:** pronta para implementar

## Objetivo

Convidar amigos pela Steam e jogar pela internet.

## Escopo

- Steamworks.NET e FishySteamworks, com P2P pelo relay da Steam.
- App ID 480 (Spacewar) nos testes.
- Criar lobby, convidar pela lista de amigos da Steam e entrar pelo convite.
- Trocar entre Tugboat (testes locais) e Steam sem mexer em código.
- O início automático do `NetworkBootstrap` (fase 02) continua só para o Tugboat no editor; na Steam, o host cria o lobby e o cliente entra pelo convite.

## Fora do escopo

- App ID próprio e página da Steam (fases 20 e 29).

## Critérios de pronto

- [ ] O host cria o lobby e um amigo entra pelo convite, de outro computador.
- [ ] Tudo das fases 01 a 04 funciona pela internet.
- [ ] Sair e voltar de uma partida não trava o jogo.
- [ ] Usuário testou com um amigo e aprovou.

## Bugs prováveis

- Steam não inicializada, por cliente da Steam fechado ou App ID errado.
- Tentar testar duas builds no mesmo PC pela Steam, o que não funciona (para isso, Tugboat).
- Callbacks da Steam que nunca são processados.
- Lobby que continua aberto depois que o host sai.

## Referências

- `CLAUDE.md`: Stack.
