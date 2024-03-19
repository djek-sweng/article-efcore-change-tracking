-- create database for "efcore"
drop database if exists db_efcore;
create database db_efcore
  character set utf8mb4
  collate utf8mb4_unicode_ci;

-- create database for "reference"
drop database if exists db_reference;
create database db_reference
  character set utf8mb4
  collate utf8mb4_unicode_ci;

use db_reference;

-- create table
drop table if exists notes;
create table notes
(
  id              int unsigned not null auto_increment,
  message         varchar(255) not null,
  created_at      timestamp default current_timestamp,
  updated_at      timestamp null on update current_timestamp,

  constraint pk_notes primary key (id)
) engine = innodb;

-- insert table data
insert into notes (message) values ('Reference note A');
insert into notes (message) values ('Reference note B');
insert into notes (message) values ('Reference note C');

-- update table data
update notes set message = 'Reference note A - modified' where id = 1;
do sleep(1);

update notes set message = 'Reference note B - modified' where id = 2;
do sleep(1);
