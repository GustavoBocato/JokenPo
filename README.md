# 🪨✂️📄 JokenPo API

Uma API simples de Jokenpô (Pedra, Papel, Tesoura, Spock e Lagarto) desenvolvida em ASP.NET Core. Permite o cadastro e deleção de jogadores, registro de jogadas e verificação do resultado da partida.

---
## Como jogar

- Clone o repositório, rode o projeto localmente.
- Abra a interface do swagger no localhost:
  
  ![image](https://github.com/user-attachments/assets/9796ce82-1311-45ca-98d1-a27ba129d667)

- Use o endpoint de post para cria jogadores, digite o nome do jogador no json do request e aperte o botão de executar.

  ![image](https://github.com/user-attachments/assets/b1236912-d21e-4a11-9bc4-050e52b7e84f)

- Crie quantos jogadores você quiser.
- Use o endpoint de get para ver o status do jogo e os jogadores existentes.

  ![image](https://github.com/user-attachments/assets/e242f20a-c3de-47f4-9371-891c04cba97d)

- Use o endpoint de delete para deletar os jogadores passando o guid deles.

  ![image](https://github.com/user-attachments/assets/9d3fe7e3-8221-4fb4-aa73-05dbf0869f5b)

- Use o endpoint de patch para registrar as jogadas nos jogadores criados, passando o guid do jogador e uma string entre as possíveis jogadas: Rock, Paper, Scissors, Spock e Lizard.

  ![image](https://github.com/user-attachments/assets/792c5341-ede0-46bf-8a38-2d16f2986a0a)

- Quando todos os jogadores tiverem jogado, o jogo termina e o resultado do jogo pode ser verificado no endpoint de get:

  ![image](https://github.com/user-attachments/assets/16d5c885-75bc-4d71-b0ef-7a561b8cd7d0)

- O jogo pode também terminar em empate:

  ![image](https://github.com/user-attachments/assets/f39babe9-1684-489f-a420-69e73c28f623)

- Depois que o jogo acaba (quando todos os jogadores jogam uma mão e se dá um get no status do jogo), o jogo reseta automaticamente e todos os jogadore são deletados:

  ![image](https://github.com/user-attachments/assets/b1a5e15f-65c4-4050-b233-9278756145a9)

## 🔧 Tecnologias Utilizadas

- .NET 8
- ASP.NET Core Web API
- MediatR
- Swagger / Swashbuckle
- C#

---

## Descrição do Código

O código implementa o desing pattern mediator. Onde requests e handlers de desses requests são definidos um a um, de forma que os handlers manuseiem os requests. Um request é uma classe de objetos que contem o mínimo de informação possível para que o seu respectivo handler possa executar sua lógica. Normamente existem dois tipos de request os de consulta (queries) e os de manipulação de dados (commands). Cada lógica desses requests existe dentro de um respectivo handler. O Handler tem acesso ao repositório que é onde de fato as manipulações dos dados ocorrem.

A controller recebe injeção de dependência do objeto mediator (que é o responsável por encaminhar os requests criados na controller para os devidos handlers). Cada endpoint da controller cria um request que é encaminhdo para o seu devido handler, que o executa acessando os dados do repository que é uma dependência injetada nesses handlers. Minimizando completamente o acoplamento entre as entidades entidades.

O algoritmo que decide quem ganhou o jogo foi implementado e encapsulado na classe GameResultDeterminator. A idéia por trás do algoritmo é que a mão de um jogador só pode estar relacionada as mãos de outros de duas formas: ela ganha da outra mão ou ela perde da outra mão. Portanto se no final do jogo um jogador tem uma mão que não perde de nenhuma outra, esse jogador é o vencedor (já que sua mão ganha de todas as outras). Para determinar se a mão de um jogador não perde para nenhuma outra, foram registradas as fraquezas de cada mão em listas estáticas dentro dessa classe GameResultDeterminator. Determinando-se o vencedor em complexidade de tempo quadrática.

![image](https://github.com/user-attachments/assets/caaab8c6-0aae-4dec-b945-4dda36a54636)

Esse código é uma implementação do seguinte desafio: https://gist.github.com/DouglasLutz/6b0b2dcf0f2c41e0c55666c9c9cd8c7d
