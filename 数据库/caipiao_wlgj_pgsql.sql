create database caipiao_wlgj
;
use caipiao_wlgj
;
CREATE TABLE admin_quanxian(
	id serial primary key,
	createtime timestamp NOT NULL default current_timestamp,
	adminid int NOT NULL,
	adminname varchar(64) NULL,
	qxid int NOT NULL,
	qxname varchar(64) NULL,
	remark varchar(2048) NULL 
)  
 
;
CREATE TABLE caizhong(
	id serial primary key,
	createtime timestamp not null default current_timestamp,
	czname varchar(32) NULL,
	remark varchar(1024) NULL 
)    
;
CREATE TABLE chongzhi(
	id serial primary key,
	createtime timestamp not null default current_timestamp,
	userid int NOT NULL,
	username varchar(64) NULL,
	status int NOT NULL,
	remark varchar(1024) NULL,
	money numeric(9, 2) NOT NULL,
	bankname varchar(128) NULL,
	realname varchar(128) NULL,
	bankno varchar(128) NULL,
	paytype int NOT NULL 
) 
 
;
CREATE TABLE emailset(
	id serial primary key,
	createtime timestamp not null default current_timestamp,
	email varchar(128) NOT NULL,
	password varchar(128) NOT NULL,
	smtp varchar(128) NOT NULL,
	cur int NOT NULL 
) 
 
;
CREATE TABLE gudong(
	id serial primary key,
	createtime timestamp not null default current_timestamp,
	username varchar(64) NULL,
	email varchar(128) NULL,
	remark varchar(1024) NULL 
) 
 
;
CREATE TABLE liushui(
	id serial primary key,
	createtime timestamp not null default current_timestamp,
	userid int NOT NULL,
	username varchar(64) NULL,
	beforemoney numeric(9, 3) NOT NULL,
	changemoney numeric(9, 3) NOT NULL,
	aftermoney numeric(9, 3) NOT NULL,
	remark varchar(1024) NULL,
	type int NOT NULL,
	xzid int NOT NULL,
	txid int NOT NULL,
	czid int NOT NULL,
	fhdate varchar(16) NULL,
	czr varchar(64) NULL 
)  
 
;
CREATE TABLE news(
	id serial primary key,
	createtime timestamp not null default current_timestamp,
	title varchar(256) NULL,
	body text NULL,
	cabh varchar(64) NULL,
	caname varchar(64) NULL,
	visitnum int NOT NULL 
)   
 
;
CREATE TABLE qihaoinfo(
	id serial primary key,
	createtime timestamp not null default current_timestamp,
	qihao varchar(32) NULL,
	starttime timestamp not null default current_timestamp,
	endtime timestamp not null default current_timestamp,
	kjtime timestamp not null default current_timestamp,
	remark varchar(1024) NULL,
	czid int NOT NULL,
	czname varchar(32) NULL,
	kjcode varchar(512) NULL,
	kjcode2 varchar(512) NULL,
	code1 int NOT NULL,
	code2 int NOT NULL,
	code3 int NOT NULL 
)    
;
CREATE TABLE quanxian(
	id serial primary key,
	createtime timestamp not null default current_timestamp,
	qxname varchar(64) NULL,
	url varchar(1024) NULL,
	bh varchar(64) NULL,
	pbh varchar(64) NULL,
	remark varchar(2048) NULL 
) 
 
;
CREATE TABLE shuxing(
	id serial primary key,
	createtime timestamp not null default current_timestamp,
	sxname varchar(128) NULL,
	sxvalue varchar(128) NULL,
	remark varchar(2048) NULL 
) 
 
;
CREATE TABLE tixian(
	id serial primary key,
	createtime timestamp not null default current_timestamp,
	userid int NOT NULL,
	username varchar(64) NULL,
	money numeric(9, 2) NOT NULL,
	remark varchar(1024) NULL,
	status int NOT NULL,
	replay varchar(1024) NULL,
	bankno varchar(128) NULL,
	bankname varchar(128) NULL,
	realname varchar(64) NULL,
	userbankid int NOT NULL,
	khh varchar(128) NULL 
)   


;
CREATE TABLE userbank(
	id serial primary key,
	createtime timestamp not null default current_timestamp,
	userid int NOT NULL,
	username varchar(64) NULL,
	bankname varchar(64) NULL,
	bankno varchar(64) NULL,
	realname varchar(64) NULL,
	remark varchar(2048) NULL,
	khh varchar(512) NULL 
) 
 
;
CREATE TABLE userinfo(
	id serial primary key,
	createtime timestamp not null default current_timestamp,
	username varchar(32) NULL,
	email varchar(32) NULL,
	password varchar(32) NULL,
	txpassword varchar(32) NULL,
	mobile varchar(32) NULL,
	address varchar(512) NULL,
	bankno varchar(64) NULL,
	bankname varchar(32) NULL,
	remark varchar(1024) NULL,
	status int NOT NULL,
	realname varchar(32) NULL,
	idcard varchar(32) NULL,
	balance numeric(9, 3) NOT NULL,
	password3 varchar(64) NULL,
	erweima varchar(1024) NULL,
	parentid int NOT NULL,
	parentname varchar(64) NULL,
	parentpath varchar(2048) NULL,
	question varchar(128) NULL,
	answer varchar(128) NULL 
)   
 
;
CREATE TABLE wanfa(
	id serial primary key,
	createtime timestamp not null default current_timestamp,
	wfname varchar(64) NULL,
	remark varchar(1024) NULL,
	czid int NOT NULL,
	basemoney numeric(9, 2) NOT NULL,
	groupname varchar(64) NULL,
	peilv numeric(9, 2) NOT NULL,
	isshow int NOT NULL,
	shortname varchar(64) NULL,
	sort int NOT NULL,
	bigname varchar(64) NULL,
	tesu int NOT NULL,
	tesu_peilv numeric(9, 2) NOT NULL,
	tesu_je numeric(9, 2) NOT NULL 
) 
 
;
CREATE TABLE xiazhuinfo(
	id serial primary key,
	createtime timestamp not null default current_timestamp,
	userid int NOT NULL,
	username varchar(32) NULL,
	czid int NOT NULL,
	czname varchar(32) NULL,
	wfid int NOT NULL,
	wfname varchar(64) NULL,
	buycode varchar(128) NULL,
	beishu numeric(9, 2) NOT NULL,
	buymoney numeric(9, 3) NOT NULL,
	remark varchar(1024) NULL,
	qihao varchar(32) NULL,
	iszj int NOT NULL,
	zjmoney numeric(9, 3) NOT NULL,
	kjcode varchar(64) NULL,
	shouxufee numeric(9, 3) NOT NULL,
	czr varchar(64) NULL,
	kjtime timestamp not null default current_timestamp 
) 
 
;
CREATE TABLE yugengdan(
	id serial primary key,
	createtime timestamp not null default current_timestamp,
	adminid int NOT NULL,
	adminname varchar(64) NULL,
	userid int NOT NULL,
	username varchar(64) NULL,
	remark varchar(1024) NULL 
) 
 
 