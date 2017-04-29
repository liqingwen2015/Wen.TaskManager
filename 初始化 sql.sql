if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MenuFunctionRelation') and o.name = 'FK_MENUACTI_REFERENCE_ACTION')
alter table MenuFunctionRelation
   drop constraint FK_MENUACTI_REFERENCE_ACTION
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('MenuFunctionRelation') and o.name = 'FK_MENUACTI_REFERENCE_MENU')
alter table MenuFunctionRelation
   drop constraint FK_MENUACTI_REFERENCE_MENU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('RoleMenuRelation') and o.name = 'FK_ROLEMENU_REFERENCE_MENU')
alter table RoleMenuRelation
   drop constraint FK_ROLEMENU_REFERENCE_MENU
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('RoleMenuRelation') and o.name = 'FK_ROLEMENU_REFERENCE_ROLE')
alter table RoleMenuRelation
   drop constraint FK_ROLEMENU_REFERENCE_ROLE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('UserRoleRelation') and o.name = 'FK_USERROLE_REFERENCE_ROLE')
alter table UserRoleRelation
   drop constraint FK_USERROLE_REFERENCE_ROLE
go

if exists (select 1
   from sys.sysreferences r join sys.sysobjects o on (o.id = r.constid and o.type = 'F')
   where r.fkeyid = object_id('UserRoleRelation') and o.name = 'FK_USERROLE_REFERENCE_USER')
alter table UserRoleRelation
   drop constraint FK_USERROLE_REFERENCE_USER
go

if exists (select 1
            from  sysobjects
           where  id = object_id('"Function"')
            and   type = 'U')
   drop table "Function"
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Menu')
            and   type = 'U')
   drop table Menu
go

if exists (select 1
            from  sysobjects
           where  id = object_id('MenuFunctionRelation')
            and   type = 'U')
   drop table MenuFunctionRelation
go

if exists (select 1
            from  sysobjects
           where  id = object_id('Role')
            and   type = 'U')
   drop table Role
go

if exists (select 1
            from  sysobjects
           where  id = object_id('RoleMenuRelation')
            and   type = 'U')
   drop table RoleMenuRelation
go

if exists (select 1
            from  sysobjects
           where  id = object_id('"User"')
            and   type = 'U')
   drop table "User"
go

if exists (select 1
            from  sysobjects
           where  id = object_id('UserRoleRelation')
            and   type = 'U')
   drop table UserRoleRelation
go

/*==============================================================*/
/* Table: "Function"                                            */
/*==============================================================*/
create table "Function" (
   Id                   int                  identity,
   Name                 nvarchar(50)         null,
   CreateTime           datetime             null default getdate(),
   EditTime             datetime             null default getdate(),
   IsDel                bit                  null default 0,
   TypeValue            int                  null,
   constraint PK_FUNCTION primary key (Id)
)
go

/*==============================================================*/
/* Table: Menu                                                  */
/*==============================================================*/
create table Menu (
   Id                   int                  identity,
   Name                 nvarchar(50)         null,
   CreateTime           datetime             null default getdate(),
   EditTime             datetime             null default getdate(),
   IsDel                bit                  null default 0,
   ParentId             int                  null,
   Url                  varchar(100)         null,
   SortNum              int                  null default 0,
   constraint PK_MENU primary key (Id)
)
go

/*==============================================================*/
/* Table: MenuFunctionRelation                                  */
/*==============================================================*/
create table MenuFunctionRelation (
   MenuId               int                  null,
   FunctionId           int                  null
)
go

/*==============================================================*/
/* Table: Role                                                  */
/*==============================================================*/
create table Role (
   Id                   int                  identity,
   Name                 nvarchar(50)         null,
   CreateTime           datetime             null default getdate(),
   EditTime             datetime             null default getdate(),
   IsDel                bit                  null default 0,
   constraint PK_ROLE primary key (Id)
)
go

/*==============================================================*/
/* Table: RoleMenuRelation                                      */
/*==============================================================*/
create table RoleMenuRelation (
   RoleId               int                  null,
   MenuId               int                  null
)
go

/*==============================================================*/
/* Table: "User"                                                */
/*==============================================================*/
create table "User" (
   Id                   int                  identity,
   Name                 varchar(50)          null,
   Email                varchar(100)         null,
   Password             varchar(100)         null,
   CreateTime           datetime             null default GETDATE(),
   EditTime             datetime             null default GETDATE(),
   IsDel                bit                  null default 0,
   constraint PK_USER primary key (Id)
)
go

/*==============================================================*/
/* Table: UserRoleRelation                                      */
/*==============================================================*/
create table UserRoleRelation (
   UserId               int                  null,
   RoleId               int                  null
)
go

alter table MenuFunctionRelation
   add constraint FK_MENUACTI_REFERENCE_ACTION foreign key (FunctionId)
      references "Function" (Id)
go

alter table MenuFunctionRelation
   add constraint FK_MENUACTI_REFERENCE_MENU foreign key (MenuId)
      references Menu (Id)
go

alter table RoleMenuRelation
   add constraint FK_ROLEMENU_REFERENCE_MENU foreign key (MenuId)
      references Menu (Id)
go

alter table RoleMenuRelation
   add constraint FK_ROLEMENU_REFERENCE_ROLE foreign key (RoleId)
      references Role (Id)
go

alter table UserRoleRelation
   add constraint FK_USERROLE_REFERENCE_ROLE foreign key (RoleId)
      references Role (Id)
go

alter table UserRoleRelation
   add constraint FK_USERROLE_REFERENCE_USER foreign key (UserId)
      references "User" (Id)
go
