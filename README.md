# Teste ZDZCode - Dev Full Stack

Este projeto foi desenvolvido como parte do processo seletivo para o cargo de Desenvolvedor no ZDZCode.

A aplicação consiste em uma API e interface para geração e consulta de carteiras digitais de estudante. 

## Requisitos

A especificação:

Teste

Pense em um problema que pode ser resolvido com controle de dados, algo como controle financeiro de despesas e receitas, controle de estoque de mercadorias, histórico de manutenção em veiculos, agendamentos de reuniões ou outro tema a sua escolha, depois de escolhido o tema que lhe agrade execute os seguintes passos:

1 - Fazer a modelagem de dados
2 - Criar esboço das telas
3 - Criar as telas utilizando VueJS + framework Nuxt + Vuetify (https://nuxtjs.org)
4 - Criar um projeto C# de API com o Visual Studio 2022 Community
5 - Criar endpoints para receber/retornar os dados para as telas criadas no item 3
6 - Salvar os dados utilizando Entity Framework, esses dados podem ser salvos em memória ou sqllite.

## Documentação

Foi utilizado Swagger para documentar todos os endpoints disponíveis.
É possível acessá-lo através da URL `https://localhost:7178/swagger/index.html`.

## O que foi utilizado
 
 - Front-End: VueJS + framework Nuxt + Vuetify
 - Back-End: .Net 6 (C#)
 - API REST (POST e GET)
 - EF Core (Dados salvos em memória)
 - Librarys: Drawing.Imaging, AutoMapper, EF Core, Json (Comunicação)
 - Swagger (documentação)

## Como executar:

Ter instalado na maquina node.js/yarn e no VS Code ter instalado extensões: Nuxt e Vuetify.

Ter SDK .Net 6 instalado na maquina, realizar a compilação e iniciar a solução.

Comando pra rodar projeto: 

yarn build

yarn dev
