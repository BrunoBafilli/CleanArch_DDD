# Desafio de Implementação de Sistema para Loja de Varejo

## Cenário
Você foi contratado para desenvolver um sistema para uma loja de varejo. A loja deseja gerenciar seus produtos, clientes e pedidos de forma organizada.

## Requisitos

### Entidades
1. **Produto**
   - ID (Guid)
   - Nome (string)
   - Descrição (string)
   - Preço (decimal)
   - Quantidade em Estoque (int)

2. **Cliente**
   - ID (Guid)
   - Nome (string)
   - Email (string)
   - Telefone (string)

3. **Pedido**
   - ID (Guid)
   - Data do Pedido (DateTime)
   - Cliente (Cliente)
   - Itens do Pedido (Lista de ItemPedido)

4. **ItemPedido**
   - Produto (Produto)
   - Quantidade (int)
   - Preço Unitário (decimal)

### Regras de Negócio
- Um produto deve ter um nome, uma descrição, um preço e uma quantidade em estoque.
- Um cliente deve ter um nome, um email e um telefone.
- Um pedido deve ter uma data, um cliente e pelo menos um item de pedido.
- A quantidade em estoque de um produto deve ser reduzida quando um pedido é feito.
- Não é possível fazer um pedido se a quantidade solicitada de um produto não estiver disponível em estoque.

### Casos de Uso
1. **Adicionar Produto**
2. **Editar Produto**
3. **Listar Produtos**
4. **Remover Produto**
5. **Adicionar Cliente**
6. **Editar Cliente**
7. **Listar Clientes**
8. **Remover Cliente**
9. **Adicionar Pedido**
10. **Listar Pedidos**

## Estrutura do Projeto

### Camadas
1. **Domain**
   - Contém as entidades, interfaces de repositório e lógica de negócios.
2. **Application**
   - Contém os casos de uso e interfaces de serviços.
3. **Infrastructure**
   - Contém a implementação dos repositórios e contexto de dados.
4. **Presentation**
   - Contém a interface de usuário ou API para interagir com a aplicação.

## Tarefas

1. **Definir as Entidades:** Crie as classes `Produto`, `Cliente`, `Pedido` e `ItemPedido`.
2. **Criar Interfaces de Repositório:** Defina as interfaces `IProdutoRepository`, `IClienteRepository` e `IPedidoRepository`.
3. **Implementar Casos de Uso:** Crie os casos de uso para adicionar, editar, listar e remover produtos e clientes, e adicionar e listar pedidos.
4. **Implementar Repositórios:** Implemente os repositórios na camada de infraestrutura.
5. **Desenvolver a Apresentação:** Crie uma API ou uma aplicação console para interagir com os casos de uso.

## Extras (Desafios Adicionais)
- **Validações:** Implementar validações adicionais, como verificação de email único para clientes.
- **Exceções:** Tratar exceções de forma adequada para garantir a robustez da aplicação.
- **Testes:** Criar testes unitários para validar a lógica de negócios e casos de uso.
