# Especificações do Projeto

<span style="color:red">Pré-requisitos: <a href="1-Documentação de Contexto.md"> Documentação de Contexto</a></span>

# Personas

Através de pesquisas de campo dentro do público alvo do projeto, foram estipuladas as personas que seguem juntamente de suas histórias de usuário, dando origem aos requisitos funcionais e não funcionais da aplicação.

## Personas

### Leonardo Souza Ferreira

<img src="img/person3.jpeg" width = "150px">

| PERFIL                                                                                                                                                                                   | EXPECTATIVAS                                                                                                                                 | ATIVIDADES                                                                                                                                                                                                                                                                                                                                 |
| ---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------- | -------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Leonardo tem 28 anos, é engenheiro de software e trabalha remotamente. Valoriza a praticidade e otimização do tempo em seu dia a dia. Gosta de tecnologia e está sempre buscando formas de tornar sua rotina mais eficiente. |Ele espera encontrar um serviço rápido e confiável para cortar o cabelo sem precisar aguardar em filas. Quer agendar horários online e encontrar um barbeiro que entenda seu estilo. | Tem uma rotina corrida e não quer perder tempo procurando barbearias ou esperando atendimento. Busca um aplicativo intuitivo para escolher um profissional, visualizar portfólios e agendar serviços conforme sua disponibilidade. |

---

### Marcos Vinícius Oliveira

<img src="img/person1.jpeg" width = "150px">

| PERFIL                                                                                                           | EXPECTATIVAS                                                                                                                                      | ATIVIDADES                                                                                                                                                                                                                                                                           |
| ---------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Marcos tem 35 anos e é gerente comercial. Seu trabalho exige uma apresentação impecável, e ele frequenta a barbearia regularmente para manter a aparência profissional. Prefere atendimento personalizado e está disposto a pagar mais por um serviço de qualidade. | Busca um aplicativo que ofereça serviços premium, como atendimento VIP, assinatura mensal e agendamento recorrente para evitar preocupações com marcações de última hora. |  Mantém um compromisso fixo com sua barbearia, mas gostaria de mais praticidade no agendamento. Está sempre atento a tendências e promoções especiais. |

---

### Diego Santana Ribeiro

<img src="img/person2.jpeg" width = "150px">

| PERFIL                                                                                                           | EXPECTATIVAS                                                                                                                                      | ATIVIDADES                                                                                                                                                                                                                                                                           |
| ---------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------- | ------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------ |
| Diego tem 22 anos, é estudante universitário e trabalha meio período. Gosta de mudar o estilo do cabelo frequentemente e acompanha tendências nas redes sociais. Procura serviços acessíveis e flexíveis. | Ele deseja encontrar barbeiros que ofereçam cortes modernos e criativos. Também busca avaliações de outros clientes e promoções para aproveitar descontos. |  Usa redes sociais para se inspirar em novos cortes e estilos. Quer um aplicativo que facilite encontrar barbeiros com habilidades específicas e permita agendamentos rápidos, mesmo de última hora. |

---


# Histórias de Usuários
A partir da compreensão do dia a dia das personas identificadas para o projeto, foram registradas as seguintes histórias de usuários.




## Arquitetura e Tecnologias

A arquitetura será baseada no modelo Cliente-Servidor, sendo o servidor uma Web API desenvolvida utilizando o .NET Framework, uma plataforma baseada em C# utilizada aplamente em projetos e com suporte contínuo da Microsoft. Para o Cliente da aplicação será utilizado o React Native, um framework desenvolvido pela Meta, que possui as características do React.js porém otimizado para despostivos móveis. 

## Project Model Canvas

Colocar a imagem do modelo construído apresentando a proposta de solução.

<img src="img/pmCanvas.webp" width="700px">


## Requisitos

As tabelas que se seguem apresentam os requisitos funcionais e não funcionais que detalham o escopo do projeto. Para determinar a prioridade de requisitos, aplicar uma técnica de priorização de requisitos e detalhar como a técnica foi aplicada.

### Requisitos Funcionais

|ID    | Descrição do Requisito  | Prioridade |
|------|-----------------------------------------|----|
|RF-001| Permitir que o cliente agende um horário online | ALTA | 
|RF-002| Enviar lembretes automáticos de agendamentos   | ALTA | 
|RF-003| Possibilitar que o cliente avalie o corte realizado | MÉDIA | 
|RF-004| Exibir uma galeria de estilos com catálogo de cortes e barbas | ALTA | 
|RF-005| Fornecer um link direto para o WhatsApp da barbearia | ALTA | 
|RF-006| Integração ao Google Maps para exibir a localização da barbearia | MÉDIA | 
|RF-007| Permitir que os barbeiros gerenciem seus horários de atendimento | ALTA | 
|RF-008| Implementar sistema de confirmação automática de agendamentos | ALTA | 
|RF-009| Oferecer um painel para os barbeiros visualizarem seus agendamentos diários | MÉDIA | 
|RF-010| Notificar os barbeiros sobre novos agendamentos ou cancelamentos | ALTA | 

### Requisitos não Funcionais

|ID     | Descrição do Requisito  |Prioridade |
|-------|-------------------------|----|
|RNF-001| O sistema deve garantir a confirmação instantânea dos agendamentos | ALTA | 
|RNF-002| A interface deve ser simples, intuitiva e visualmente atraente   | ALTA | 
|RNF-003| Deve ser otimizado para dispositivos móveis (Android e iOS) | ALTA | 
|RNF-004| Deve carregar a galeria de estilos rapidamente | MÉDIA | 
|RNF-005| Suportar notificações push para lembretes de agendamento | ALTA | 


## Restrições

O projeto está restrito pelos itens apresentados na tabela a seguir.

|ID| Restrição                                                           |
|--|-------------------------------------------------------              |
|01| O projeto deverá ser entregue até o final do semestre               |
|02| A confirmação automática de agendamentos dependerá de conexão ativa |
|03| O desenvolvimento deve ser feito sem investir em serviços pagos     |


## Diagrama de Casos de Uso

<img src="img/sistemav4.svg" width="700px">


## Modelo ER (Projeto Conceitual)

O Modelo ER representa através de um diagrama como as entidades (coisas, objetos) se relacionam entre si na aplicação interativa.

Sugestão de ferramentas para geração deste artefato: LucidChart e Draw.io.

A referência abaixo irá auxiliá-lo na geração do artefato “Modelo ER”.

> - [Como fazer um diagrama entidade relacionamento | Lucidchart](https://www.lucidchart.com/pages/pt/como-fazer-um-diagrama-entidade-relacionamento)

## Projeto da Base de Dados

O projeto da base de dados corresponde à representação das entidades e relacionamentos identificadas no Modelo ER, no formato de tabelas, com colunas e chaves primárias/estrangeiras necessárias para representar corretamente as restrições de integridade.
