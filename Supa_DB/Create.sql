/*==============================================================*/
/* DBMS name:      Microsoft SQL Server 2008                    */
/* Created on:     11/25/2014 19:02:20                          */
/*==============================================================*/

drop table Orders;
drop table Users;
drop table Inventory;
drop table Markets;
drop table Goods;
drop table Types3;
drop table Types2;
drop table Types1;

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Goods') and o.name = 'FK_GOODS_UNDER_TYPES3')
alter table Goods
   drop constraint FK_GOODS_UNDER_TYPES3
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Inventory') and o.name = 'FK_INVENTOR_RELATIONS_MARKETS')
alter table Inventory
   drop constraint FK_INVENTOR_RELATIONS_MARKETS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Inventory') and o.name = 'FK_INVENTOR_RELATIONS_GOODS')
alter table Inventory
   drop constraint FK_INVENTOR_RELATIONS_GOODS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Orders') and o.name = 'FK_ORDERS_RELATIONS_USERS')
alter table Orders
   drop constraint FK_ORDERS_RELATIONS_USERS
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Orders') and o.name = 'FK_ORDERS_RELATIONS_INVENTOR')
alter table Orders
   drop constraint FK_ORDERS_RELATIONS_INVENTOR
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Types2') and o.name = 'FK_TYPES2_BELONG_TO_TYPES1')
alter table Types2
   drop constraint FK_TYPES2_BELONG_TO_TYPES1
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('Types3') and o.name = 'FK_TYPES3_BELONG_TO_TYPES2')
alter table Types3
   drop constraint FK_TYPES3_BELONG_TO_TYPES2
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Goods')
            and   name  = 'Under_FK'
            and   indid > 0
            and   indid < 255)
   drop index Goods.Under_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Goods')
            and   type = 'U')
   drop table Goods
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Inventory')
            and   name  = 'Relationship_6_FK'
            and   indid > 0
            and   indid < 255)
   drop index Inventory.Relationship_6_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Inventory')
            and   name  = 'Relationship_5_FK'
            and   indid > 0
            and   indid < 255)
   drop index Inventory.Relationship_5_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Inventory')
            and   type = 'U')
   drop table Inventory
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Markets')
            and   type = 'U')
   drop table Markets
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Orders')
            and   name  = 'Relationship_9_FK'
            and   indid > 0
            and   indid < 255)
   drop index Orders.Relationship_9_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Orders')
            and   name  = 'Relationship_8_FK'
            and   indid > 0
            and   indid < 255)
   drop index Orders.Relationship_8_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Orders')
            and   type = 'U')
   drop table Orders
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Types1')
            and   type = 'U')
   drop table Types1
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Types2')
            and   name  = 'Belong_To_1_FK'
            and   indid > 0
            and   indid < 255)
   drop index Types2.Belong_To_1_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Types2')
            and   type = 'U')
   drop table Types2
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('Types3')
            and   name  = 'Belong_To_2_FK'
            and   indid > 0
            and   indid < 255)
   drop index Types3.Belong_To_2_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Types3')
            and   type = 'U')
   drop table Types3
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Users')
            and   type = 'U')
   drop table Users
go

/*==============================================================*/
/* Table: Goods                                                 */
/*==============================================================*/
create table Goods (
   GoodID               char(256)            not null,
   GoodName             char(256)            not null,
   Class3               char(256)            null,
   constraint PK_GOODS primary key nonclustered (GoodID)
)
go

/*==============================================================*/
/* Index: Under_FK                                              */
/*==============================================================*/
create index Under_FK on Goods (
Class3 ASC
)
go

/*==============================================================*/
/* Table: Inventory                                             */
/*==============================================================*/
create table Inventory (
   GoodID               char(256)            not null,
   MarketName           char(256)            not null,
   Location             char(256)            null,
   Discount             float                null,
   Remaining            int                  null,
   Price                float                null,
   constraint PK_INVENTORY primary key nonclustered (GoodID, MarketName)
)
go

/*==============================================================*/
/* Index: Relationship_5_FK                                     */
/*==============================================================*/
create index Relationship_5_FK on Inventory (
MarketName ASC
)
go

/*==============================================================*/
/* Index: Relationship_6_FK                                     */
/*==============================================================*/
create index Relationship_6_FK on Inventory (
GoodID ASC
)
go

/*==============================================================*/
/* Table: Markets                                               */
/*==============================================================*/
create table Markets (
   MarketName           char(256)            not null,
   MarketAdd            char(256)            null,
   MarketEst            int                  null,
   constraint PK_MARKETS primary key nonclustered (MarketName)
)
go

/*==============================================================*/
/* Table: Orders                                                */
/*==============================================================*/
create table Orders (
   GoodID               char(256)            not null,
   MarketName           char(256)            not null,
   UserId               int                  not null,
   Amount               int                  null,
   IsPayed              bit                  null,
   constraint PK_ORDERS primary key nonclustered (GoodID, MarketName, UserId)
)
go

/*==============================================================*/
/* Index: Relationship_8_FK                                     */
/*==============================================================*/
create index Relationship_8_FK on Orders (
UserId ASC
)
go

/*==============================================================*/
/* Index: Relationship_9_FK                                     */
/*==============================================================*/
create index Relationship_9_FK on Orders (
GoodID ASC,
MarketName ASC
)
go

/*==============================================================*/
/* Table: Types1                                                */
/*==============================================================*/
create table Types1 (
   Class1               char(256)            not null,
   constraint PK_TYPES1 primary key nonclustered (Class1)
)
go

/*==============================================================*/
/* Table: Types2                                                */
/*==============================================================*/
create table Types2 (
   Class2               char(256)            not null,
   Class1               char(256)            null,
   constraint PK_TYPES2 primary key nonclustered (Class2)
)
go

/*==============================================================*/
/* Index: Belong_To_1_FK                                        */
/*==============================================================*/
create index Belong_To_1_FK on Types2 (
Class1 ASC
)
go

/*==============================================================*/
/* Table: Types3                                                */
/*==============================================================*/
create table Types3 (
   Class3               char(256)            not null,
   Class2               char(256)            not null,
   constraint PK_TYPES3 primary key nonclustered (Class3)
)
go

/*==============================================================*/
/* Index: Belong_To_2_FK                                        */
/*==============================================================*/
create index Belong_To_2_FK on Types3 (
Class2 ASC
)
go

/*==============================================================*/
/* Table: Users                                                 */
/*==============================================================*/
create table Users (
   UserId               int                  not null identity,
   UserName             char(256)            null,
   Password             char(256)            null,
   constraint PK_USERS primary key nonclustered (UserId)
)
go

alter table Goods
   add constraint FK_GOODS_UNDER_TYPES3 foreign key (Class3)
      references Types3 (Class3)
go

alter table Inventory
   add constraint FK_INVENTOR_RELATIONS_MARKETS foreign key (MarketName)
      references Markets (MarketName)
go

alter table Inventory
   add constraint FK_INVENTOR_RELATIONS_GOODS foreign key (GoodID)
      references Goods (GoodID)
go

alter table Orders
   add constraint FK_ORDERS_RELATIONS_USERS foreign key (UserId)
      references Users (UserId)
go

alter table Orders
   add constraint FK_ORDERS_RELATIONS_INVENTOR foreign key (GoodID, MarketName)
      references Inventory (GoodID, MarketName)
go

alter table Types2
   add constraint FK_TYPES2_BELONG_TO_TYPES1 foreign key (Class1)
      references Types1 (Class1)
go

alter table Types3
   add constraint FK_TYPES3_BELONG_TO_TYPES2 foreign key (Class2)
      references Types2 (Class2)
go

