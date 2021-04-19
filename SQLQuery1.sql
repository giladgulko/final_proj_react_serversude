
CREATE TABLE memoType_g_2021 (
[id] smallint IDENTITY (1, 1) NOT NULL ,
[name] nvarchar (20) NOT NULL ,
	Primary key (id)
);

insert into memoType_g_2021(name)
values('Ideas')

select *from memoType_g_2021

select *from memos_g_2021

create table memos_g_2021(
[memo_id] smallint IDENTITY (1, 1) NOT NULL,
[type_id] smallint not null,
memo_text varchar(500) not null
primary key(memo_id),
constraint fk13 foreign key(type_id) references memoType_g_2021(id), 
);


insert into memos_g_2021(type_id,memo_text)
values(1,'go to the doctor in 11/1/2021')


