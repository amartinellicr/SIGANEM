select [prmoc_pco_ofici], [prmoc_pco_moned], [prmoc_pco_produ], [prmoc_pnu_oper]
from [godb999].[prmoc]
where [prmoc_estado] = 'A'
and [prmoc_pcoctamay] <> 815
and [prmoc_pse_proces] = 1
and [prmoc_pnu_contr] = 0
and [prmoc_pco_moned] = 2
and len([prmoc_pnu_oper]) = 6
order by [prmoc_pnu_oper]


select [prmca_pco_ofici], [prmca_pco_moned], [prmca_pnu_contr], [prmca_pfe_defin]
from [godb999].[prmca]
where [prmca_estado] = 'A'
and [prmca_pfe_defin] > 20160722
and [prmca_pco_moned] = 1
order by [prmca_pnu_contr] 


select *
from [godb999].[prmgt]
where [prmgt_estado] = 'A'
and [prmgt_pco_ofici] = 250
and [prmgt_pco_moned] = 1
and [prmgt_pco_produ] = 2
and [prmgt_pnu_oper] = 48279


/*
407-1- 2400156
377-1- 2400829
220-2- 2401077


*/



--select *
--from [godb999].[prmgt]
--where [prmgt_estado] = 'A'
--and [prmgt_pnuidegar] = 201711200010
