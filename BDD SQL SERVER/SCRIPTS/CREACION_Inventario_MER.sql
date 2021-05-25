/*==============================================================*/
/* DBMS name:      Microsoft SQL Server                      */
/* Created on:     24/5/2021 12:55:04                           */
/*==============================================================*/


if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PRODUCTO') and o.name = 'FK_PRODUCTO_CAT_PROD_CATEGORI')
alter table PRODUCTO
   drop constraint FK_PRODUCTO_CAT_PROD_CATEGORI
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PRODUCTO') and o.name = 'FK_PRODUCTO_MAR_PROD_MARCA')
alter table PRODUCTO
   drop constraint FK_PRODUCTO_MAR_PROD_MARCA
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PRODUCTO') and o.name = 'FK_PRODUCTO_PROV_PROD_PROVEEDO')
alter table PRODUCTO
   drop constraint FK_PRODUCTO_PROV_PROD_PROVEEDO
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('PRODUCTOS_HISTORICO') and o.name = 'FK_PRODUCTO_PROD_HIST_PRODUCTO')
alter table PRODUCTOS_HISTORICO
   drop constraint FK_PRODUCTO_PROD_HIST_PRODUCTO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('CATEGORIA')
            and   type = 'U')
   drop table CATEGORIA
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MARCA')
            and   type = 'U')
   drop table MARCA
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PRODUCTO')
            and   name  = 'MAR_PROD_FK'
            and   indid > 0
            and   indid < 255)
   drop index PRODUCTO.MAR_PROD_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PRODUCTO')
            and   name  = 'PROV_PROD_FK'
            and   indid > 0
            and   indid < 255)
   drop index PRODUCTO.PROV_PROD_FK
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PRODUCTO')
            and   name  = 'CAT_PROD_FK'
            and   indid > 0
            and   indid < 255)
   drop index PRODUCTO.CAT_PROD_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PRODUCTO')
            and   type = 'U')
   drop table PRODUCTO
go

if exists (select 1
            from  sysindexes
           where  id    = object_id('PRODUCTOS_HISTORICO')
            and   name  = 'PROD_HIST_FK'
            and   indid > 0
            and   indid < 255)
   drop index PRODUCTOS_HISTORICO.PROD_HIST_FK
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PRODUCTOS_HISTORICO')
            and   type = 'U')
   drop table PRODUCTOS_HISTORICO
go

if exists (select 1
            from  sysobjects
           where  id = object_id('PROVEEDOR')
            and   type = 'U')
   drop table PROVEEDOR
go

/*==============================================================*/
/* Table: CATEGORIA                                             */
/*==============================================================*/
create table CATEGORIA (
   CAT_ID               int                  identity,
   CAT_NOMBRE           varchar(100)         null,
   constraint PK_CATEGORIA primary key nonclustered (CAT_ID)
)
go

/*==============================================================*/
/* Table: MARCA                                                 */
/*==============================================================*/
create table MARCA (
   MAR_ID               int                  identity,
   MAR_NOMBRE           varchar(100)         null,
   constraint PK_MARCA primary key nonclustered (MAR_ID)
)
go

/*==============================================================*/
/* Table: PRODUCTO                                              */
/*==============================================================*/
create table PRODUCTO (
   PROD_ID              int                  identity,
   CAT_ID               int                  null,
   PROV_ID              int                  null,
   MAR_ID               int                  null,
   PROD_DESCRIPCION     varchar(100)         not null,
   PROD_CANTIDAD        bigint               not null,
   PROD_PRECIO_UNI      float                not null,
   PROD_LARGO           float                not null,
   PROD_ANCHO           float                not null,
   PROD_PROFUNDIDAD     float                not null,
   constraint PK_PRODUCTO primary key nonclustered (PROD_ID)
)
go

/*==============================================================*/
/* Index: CAT_PROD_FK                                           */
/*==============================================================*/
create index CAT_PROD_FK on PRODUCTO (
CAT_ID ASC
)
go

/*==============================================================*/
/* Index: PROV_PROD_FK                                          */
/*==============================================================*/
create index PROV_PROD_FK on PRODUCTO (
PROV_ID ASC
)
go

/*==============================================================*/
/* Index: MAR_PROD_FK                                           */
/*==============================================================*/
create index MAR_PROD_FK on PRODUCTO (
MAR_ID ASC
)
go

/*==============================================================*/
/* Table: PRODUCTOS_HISTORICO                                   */
/*==============================================================*/
create table PRODUCTOS_HISTORICO (
   HIST_ID              int                  identity,
   PROD_ID              int                  null,
   HIST_FECHA_MODIFICACION datetime             null,
   HIST_STOCK           bigint               null,
   constraint PK_PRODUCTOS_HISTORICO primary key nonclustered (HIST_ID)
)
go

/*==============================================================*/
/* Index: PROD_HIST_FK                                          */
/*==============================================================*/
create index PROD_HIST_FK on PRODUCTOS_HISTORICO (
PROD_ID ASC
)
go

/*==============================================================*/
/* Table: PROVEEDOR                                             */
/*==============================================================*/
create table PROVEEDOR (
   PROV_ID              int                  identity,
   PROV_NOMBRE          varchar(100)         null,
   constraint PK_PROVEEDOR primary key nonclustered (PROV_ID)
)
go

alter table PRODUCTO
   add constraint FK_PRODUCTO_CAT_PROD_CATEGORI foreign key (CAT_ID)
      references CATEGORIA (CAT_ID)
go

alter table PRODUCTO
   add constraint FK_PRODUCTO_MAR_PROD_MARCA foreign key (MAR_ID)
      references MARCA (MAR_ID)
go

alter table PRODUCTO
   add constraint FK_PRODUCTO_PROV_PROD_PROVEEDO foreign key (PROV_ID)
      references PROVEEDOR (PROV_ID)
go

alter table PRODUCTOS_HISTORICO
   add constraint FK_PRODUCTO_PROD_HIST_PRODUCTO foreign key (PROD_ID)
      references PRODUCTO (PROD_ID)
go

