# Fase 06: Voz por proximidade

**Marco:** Protótipo
**Status:** pronta para implementar

## Objetivo

Ouvir os amigos pela voz, com o volume caindo com a distância.

## Escopo

- Captura pela API de voz do Steamworks, envio pelo FishNet e reprodução num `AudioSource` 3D na cabeça de cada jogador.
- Voz aberta por padrão, com opção de apertar para falar.
- Volume da voz ajustável.

## Fora do escopo

- Megafone, rádio e abafamento pelo rotor (fases 14 e 25).

## Critérios de pronto

- [ ] Dois jogadores se ouvem pela Steam, com o volume caindo com a distância.
- [ ] Sem eco, sem estalos e com atraso aceitável.
- [ ] Quem não está falando não gasta rede à toa.
- [ ] Usuário testou com um amigo e aprovou.

## Bugs prováveis

- Taxa de amostragem errada, deixando a voz acelerada ou lenta.
- Buffer de áudio estourando e causando estalos.
- Ouvir a própria voz.
- Voz tocando na posição errada depois de renascer.

## Referências

- GDD: Voz por proximidade.
