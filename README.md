## Urna Eletrônica (Votação exclusiva para Presidente)

### DESAFIO: desenvolver uma urna eletrônica
### Tecnologias Utilizadas:
Back-end: ASP.Net Core 3.1, Entity Framework, MVC e DDD.
  
### Descrição Back-end

 - Desenvolver uma API om C# e Entity Framework (o body de retorno e de envio deverá ser em JSON), com os seguintes endpoints:
 
 1. **/candidate [via POST]**: Registro de candidatos.
 2. **/candidate  [via DELETE]**: Exclusão de candidatos.
 3. **/vote [via POST]**: cadastro dos votos. Deverá tratar os votos nulos.
 4. **/votes [via GET]**: retorna os  candidatos (nome, legenda...) com a quantidade de votos que cada um recebeu.
 
 - O registro de candidatos deverá conter:
 1. **Nome Completo** (_string_)
 2. **Nome do Vice** (_string_)
 3. **Data de registro** (_DateTime_)
 4. **Legenda** (_int32_)
 
 - O registro de votos deverá conter:
 1. **Id do candidato** (_referência à tabela de candidatos_)
 2. **Data do voto** (_DateTime_)
