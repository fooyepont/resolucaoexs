
--Faça uma busca utilizando comando SQL que traga o código, a razão social e o(s) telefone(s) de todos os clientes do estado de São Paulo (código “SP”);


SELECT c.id_cliente, c.razao_social, t.numero
FROM Clientes c
JOIN Telefones t ON c.id_cliente = t.id_cliente
WHERE c.estado = 'SP';