<h2><a href= "https://www.mackenzie.br">Universidade Presbiteriana Mackenzie</a></h2>
<h3><a href= "https://www.mackenzie.br/graduacao/sao-paulo-higienopolis/sistemas-de-informacao">Sistemas de Informação</a></h3>


# Projeto: *TipFlix - Sistema de Recomendação de Filmes*

# Grupo: *CGJS*

# Descrição

A aplicação desenvolvida é uma aplicação web com design mobile first. Trata-se de uma aplicação que busca recomendar filmes através de uma ferramenta de busca por gênero, que contém um algoritmo capaz de selecionar filmes do gênero selecionado com base nas pontuações dadas por usuários do site imdb. O conteúdo é lido através de uma API.

O usuário da aplicação também pode procurar títulos diretamente usando filtro de gênero, visualizar as informações de um título e adicionar ou excluir títulos de uma lista de favoritos.

# Documentação

Os arquivos da documentação deste projeto estão na pasta [/docs](/docs), e o seu conteúdo é publicado em **https://github.com/camilasp/ppads-cgjs**.

# Utilização

Realize o clone do projeto em seu computador primeiramente.

Faça o download do Docker Windows e abra o CMD dentro da pasta raiz do clone e realize o seguinte comando: docker compose up -d
Este comando irá criar as imagens de banco de dados em containers.

Agora, instale o sdk para o .NET 7 e a extensão para CMD do EF Core através d seguinte comando (em qualquer prompt): dotnet tool install --global dotnet-ef

Dentro da pasta do clone do projeto, navegue até a pasta api/Infrastructurer e abra um CMD dentro desta pasta executando: dotnet ef --startup-project ../TipFlix/ database update
Irá criar as tabelas no banco de dados e suas relações.

Para realizar o build da solução, na pasta api/TipFlix realize o seguinte comando: dotnet build
Isso criar a pasta bin, e lá estarão todas as dependencias e o executavel TipFlix.exe, que irá executar o backend.

Para o front, ainda dentro da pasta raiz do clone, entre em frontend e abra o cmd nesta pasta com o comando: npm i
Serão baixadas todas as dependencias do projeto. (Importante ter o Node.js na máquina)

Com o mesmo prompt aberto, digite: npm start
Pronto seu frontend estará aberto e funcionando.
