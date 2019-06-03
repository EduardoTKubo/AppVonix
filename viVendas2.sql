

	use CarSystem 

	CREATE view [dbo].[viVendas2] as
	select data ,hora ,turno ,(select top 1 nomecompleto from usuario where cpf = operador ) as operador ,
		   cast( case when estorno = 1 then 'estorno' else ( case when tp_standby = 1 then 'stand-by' else ( case when STATUS_VENDA is not null  then STATUS_VENDA else 'back office' end  ) end ) end as varchar ) as status ,
		   cast( case when tp_origem = 1 then 'Ativo' when tp_origem = 2 then 'Receptivo' else 'Renovação' end as nvarchar ) as origem_vda ,
		   origem ,id_venda ,nome ,fantasia ,RAMO_ATIV ,pessoa ,cpf doc ,
		   cast( case when pessoa = 'PF' then rg else ie end as nvarchar) as rg_ie ,ORGAO_EMISSOR ,UF_RG ,DT_EXP_RG ,
		   DTNASC ,sexo ,email ,ddd1 ,TEL1 ,ddd2 ,TEL2 ,
		   RESPONS responsavel ,CPF_RESPONS cpf_do_resp ,EMAIL_RESPONS email_do_resp ,DDD1_RESPONS ddd_resp ,TEL1_RESPONS fone_resp ,
		   cep ,LOGRADOURO ,numero ,compl ,bairro ,cidade ,uf ,
		   plano ,ASSIST_24HRS ,INSTAL_ATV ,TX_ENTREGA , replace(cast(valor as decimal(18,2)),'.',',') valorf ,
		   forma_pagto ,melhor_dia ,
		   administradora ,num_cartao ,cod_seg ,val_cartao ,
		   banco ,agencia ,dig_ag ,conta ,dig_conta ,
		   cod_site codigo_gerado ,obs_wel obs ,(select top 1 nomecompleto from usuario where cpf = office ) as back_office	     
	from vendas
	go
