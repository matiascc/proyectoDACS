INSERT INTO producto (id,precio) VALUES (0,111);
INSERT INTO producto (id,precio) VALUES (1,100);
INSERT INTO producto (id,precio) VALUES (2,150);
INSERT INTO producto (id,precio) VALUES (3,300);
INSERT INTO producto (id,precio) VALUES (4,50);
INSERT INTO producto (id,precio) VALUES (5,550);
INSERT INTO producto (id,precio) VALUES (6,675);
INSERT INTO producto (id,precio) VALUES (7,110);
INSERT INTO producto (id,precio) VALUES (8,230);
INSERT INTO producto (id,precio) VALUES (9,500);
INSERT INTO producto (id,precio) VALUES (10,1050);
INSERT INTO reparto (id,fecha,finalizado) VALUES (1,'2019-07-30',true);
INSERT INTO pedido (id,fechaCreacion,fechaLimite,entregado,idCliente,reparto) VALUES (1,'2019-04-15','2019-05-28',0,1,1);
INSERT INTO pedido (id,fechaCreacion,fechaLimite,entregado,idCliente) VALUES (2,'2019-05-15','2019-06-28',0,2);
INSERT INTO pedido (id,fechaCreacion,fechaLimite,entregado,idCliente) VALUES (3,'2019-06-15','2019-07-28',0,3);
INSERT INTO pedido (id,fechaCreacion,fechaLimite,entregado,idCliente) VALUES (4,'2019-07-15','2019-08-28',0,4);
INSERT INTO itempedido (id,cantidad,precio,idproducto,pedido) VALUES (1,4,400,1,1);
INSERT INTO itempedido (id,cantidad,precio,idproducto,pedido) VALUES (2,7,1050,2,1);
INSERT INTO itempedido (id,cantidad,precio,idproducto,pedido) VALUES (3,2,600,3,1);
INSERT INTO itempedido (id,cantidad,precio,idproducto,pedido) VALUES (4,5,250,4,2);
INSERT INTO itempedido (id,cantidad,precio,idproducto,pedido) VALUES (5,1,550,5,2);
INSERT INTO itempedido (id,cantidad,precio,idproducto,pedido) VALUES (6,2,1350,6,2);
INSERT INTO itempedido (id,cantidad,precio,idproducto,pedido) VALUES (7,3,330,7,3);
INSERT INTO itempedido (id,cantidad,precio,idproducto,pedido) VALUES (8,5,1150,8,3);
INSERT INTO itempedido (id,cantidad,precio,idproducto,pedido) VALUES (9,1,500,9,4);
INSERT INTO itempedido (id,cantidad,precio,idproducto,pedido) VALUES (10,1,1050,10,4);