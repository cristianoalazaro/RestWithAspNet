CREATE TABLE IF NOT EXISTS person(ID         bigint(20) not null auto_increment
								 ,address    varchar(100) not null
                                 ,first_name varchar(80) not null
                                 ,last_name  varchar(80) not null
                                 ,gender     varchar(6)  not null
                                 ,primary key(ID))