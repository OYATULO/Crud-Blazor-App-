1: Api_Company -> Asp.Net core Web API
2: Models_Company
3: WEB_Company -> UI Blazor

USES:
[
	EntityFrameworkCore 	   	7.0.9
	EntityFrameworkCore.Design 	7.0.9
	EntityFrameworkCore.Tools  	7.0.9
	EntityFrameworkCore.PostgreSQL  7.0.4

Model,Controller,Interface, UI Blazor
bootstrap v5
]

ConnectionStrings: Server=localhost;Database=MyCompany;User Id=postgres;Password=******;
Command : 
	Add-migaration myfirstMigration1
	update-datebase
 
=================================== start  API  =============================
 "openapi": "3.0.1",
  "info": {
    "title": "Api_Company",
    "version": "1.0"
  },
 
********** Api Company **********

    "/api/Company": { "get" , "post" },
    "/api/Company/{Id}": { "get","delete"},
    "/api/Company/Update": {"put" },

********** Api Communication **********

    "/api/Communication": { "get", "post" },
    "/api/Communication/{Id}": { "get","delete" },
    "/api/Communication/Update": { "put" },
    "/api/Communication/company/{Id}": {"get",},
    "/api/Communication/contact{Id}": {"get" },

********** Api Contact **********

    "/api/Contact": { "get","post" },
    "/api/Contact/GetById/{Id}": { "get" },
    "/api/Contact/Update": { "put"},
    "/api/Contact/{Id}": {"delete" },
    "/api/Contact/{CompanyId}": {"get"}

=================================== end API  =============================

=============================  Models_Company  ===========================	
	Communication
	Contact
	MCompany

=============================  WEB_Company ===============================

MENU: 
	Главный
	Компания
	        Добавть	| Обновить | Удалить | Изменить | Поиск
	Сотрудник
		      Добавть	| Обновить | Удалить | Изменить | Поиск
	Комуникация
		      Добавть	| Обновить | Удалить | Изменить | Поиск

