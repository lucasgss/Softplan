# Softplan
Repositório com a solução do desafio técnico da empresa Softplan.

## Descrição do desafio:

Você deverá criar duas API's uma com dois endpoints e outra com um endpoint:

#### API 1
1) Retorna taxa de juros
Responde pelo path relativo "/taxaJuros"
Retorna o juros de 1% ou 0,01 (fixo no código)
```
Exemplo: /taxaJuros Resultado esperado: 0,01
```

#### API 2
1) Calcula Juros
Responde pelo path relativo "/calculajuros" <br />
Ela faz um cálculo em memória, de juros compostos, conforme abaixo: 
```
Valor Final = Valor Inicial * (1 + juros) ^ Tempo
```
Valor inicial é um decimal recebido como parâmetro. <br />
Valor do Juros deve ser consultado na API 1. <br />
Tempo é um inteiro, que representa meses, também recebido como parâmetro. <br />
^ representa a operação de potência. <br />
Resultado final deve ser truncado (sem arredondamento) em duas casas decimais. <br />
```
Exemplo: /calculajuros?valorinicial=100&meses=5 Resultado esperado: 105,10
```
2) Show me the code
Este responde pelo path relativo /showmethecode Deverá retornar a url de onde encontra-se o fonte no github <br />

Esperamos que a entrega tenha:
1. Código fonte em asp.net core no github (Mostrar conhecimento básico
de git)
2. Teste unitários (Mostrar conhecimento de testes unitários, se possível TDD)

### Extras
1. Utilização de Docker
2. Teste de integração da API em linguagem de sua preferência (Damos
importância para pirâmide de testes)
3. Utilizar swagger
