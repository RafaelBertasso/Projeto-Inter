# Projeto Agendamento de serviços para a empresa Rio Preto Piscinas
 Este é um projeto ASP.NET MVC desenvolvido para um sistema de agendamento de serviços, onde os clientes podem reservar horários e visualizar serviços disponíveis. O sistema foi projetado para garantir que os agendamentos sejam feitos em dias úteis e que cada horário seja agendado somente uma vez.

# Funcionalidades
- **Cadastro de Clientes, Funcionários e Serviços**: Os funcionários podem registrar novos clientes, funcionários e adicionar serviços disponíveis no sistema.
- **Agendamento de Horários**: Permite selecionar uma data e um horário para o agendamento do serviço, atualizando automaticamente a disponibilidade
- **Evitar conflito de horários**: Quando um horário é agendado, ele é automaticamente retirado da lista de horários disponíveis, para que nenhum outro cliente possa agenda-lo
- **Controle de dias úteis**: O sistema permite agendamento somente de segunda a sexta-feira, das 8h00 às 17h30
- **Interface intuitiva**: Interface amigável, com dropdowns para seleção de horários disponíveis e serviços

  # Tecnologias Utilizadas 
- **ASP.NET MVC 5**
- **Entity Framework**
- **SQL Server**
- **Bootstrap**
- **HTML/CSS e Javascript**
