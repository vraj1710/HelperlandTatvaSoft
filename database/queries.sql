

create table helper
(
help_id int primary key,
f_name nvarchar(20),
l_name nvarchar(20),
email nvarchar(20),
password nvarchar(20),
mob_no int,
address nvarchar(100)
)


create table order1
(
ord_id int primary key,
invoice_id int,
cust_id int,
ser_date date,
start_time time,
end_time time,
total_time time,
address nvarchar(100),
extra_service nvarchar(100),
pets binary(50),
comments nvarchar(50)
)


create table address
(
add_id int primary key,
house_no int,
city nvarchar(20),
zip_code int,
state nvarchar(20)
)



create table reschedule_order
(
ord_id int primary key,
new_date date,
new_start_time time,
new_end_time time
)

create table cancel_order
(
ord_id int primary key,
reason nvarchar(50)
)

create table refund
(
invoice_id int primary key ,
refund_amount int ,
comment nvarchar(50)
)

create table cancel_order
(
ord_id int primary key,
reason nvarchar(100)
)

create table payment
(
ord_id int primary key,
invoice_id int,
amount int,
card_no int,
exp_date date, 
cvv int
)

create table invoice
(
invoice_id int primary key,
ord_id int ,
cust_id int
)

create table login
(
email nvarchar(20),
password nvarchar(20)
)

Alter table order1 add constraint order_invoice_id_FK foreign key (invoice_id) references invoice(invoice_id)

alter table payment add constraint payment_invoice_id_FK foreign key (invoice_id) references invoice(invoice_id)

alter table invoice add constraint invoice_ord_id_FK foreign key (ord_id) references order1(ord_id)

alter table invoice add constraint invoice_cust_id_FK foreign key (cust_id) references customer(cust_id)
