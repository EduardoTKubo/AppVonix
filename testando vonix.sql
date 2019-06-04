

	use CarSystem 

	select * from usuario where cpf='07703803871' 

	select top 2 * from cadastro where origem = 'BASE_RENOVACAO_12FEV2019' and uso = 0 and ddd1 = 11 and uso2 = 100


		update cadastro set fone1= 979575426 ,operador=null ,data=null ,horario=null ,duracao=null ,uso=0 ,
							repasses=0 ,qtelagendou=0 ,resultado=null  ,motivo=null ,obs=null where codigo = 174360

		update cadastro set fone1= 993892225 ,operador=null ,data=null ,horario=null ,duracao=null ,uso=0 ,
							repasses=0 ,qtelagendou=0 ,resultado=null  ,motivo=null ,obs=null where codigo = 174363

		update cadastro set fone1= 989673293 ,operador=null ,data=null ,horario=null ,duracao=null ,uso=0 ,
							repasses=0 ,qtelagendou=0 ,resultado=null  ,motivo=null ,obs=null where codigo = 174439



		update cadastro set fone1= 992496140 ,uso1 = 0 ,res1 = null ,operador='07703803871' ,uso=13 ,
							qtelagendou = 0 where codigo in ( 174360,174363,174439 )

		select * from cadastro where codigo in ( 174360,174363,174439 )



		select * from cadastro where operador = '07703803871' 

		update cadastro set uso1=0 ,res1=null ,dddat=null ,foneat=null ,operador=null ,data=null ,horario=null ,duracao=null ,uso=0 ,
							repasses=0 ,qtelagendou=0 ,resultado=null  ,motivo=null ,obs=null where 
							codigo in ( 174243,174463,172677,172678,172679,175907 )

		update cadastro set uso2=0 ,res2=null where codigo in ( 174463 )

		
		select * from agenda where operador = '07703803871' 
			delete from agenda where operador = '07703803871' 


		select * from LIGACAO where operador = '07703803871' order by id desc 
			delete from LIGACAO where operador = '07703803871' 


			





		use net_2013

		select * from vendas where ID_VENDA = 468956 
			update vendas set turno = 'EQUIPE 5' where ID_VENDA = 468956 

		select * from usuario where usuario = 'CAMILA PAULINO' 
