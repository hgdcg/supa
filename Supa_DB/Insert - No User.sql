/* Delete old data */
delete from Orders;
delete from Inventory;
delete from Goods;
delete from Types3;
delete from Types2;
delete from Types1;
delete from Markets;

/* Insert data */
insert into Markets (MarketName, MarketAdd, MarketEst) values ('1�ŵ�', '˼��¥', '5');
insert into Markets (MarketName, MarketAdd, MarketEst) values ('2�ŵ�', '����¥', '5');

insert into Types1 (Class1) values ('ʳƷ����');
insert into Types1 (Class1) values ('���͸�ʳ');
insert into Types1 (Class1) values ('����ϴ��');
insert into Types1 (Class1) values ('�Ҿ���Ʒ');

insert into Types2 (Class1, Class2) values ('ʳƷ����', 'ţ����Ʒ');
insert into Types2 (Class1, Class2) values ('ʳƷ����', '�ǹ�');
insert into Types2 (Class1, Class2) values ('ʳƷ����', '����');
insert into Types2 (Class1, Class2) values ('���͸�ʳ', '��������');
insert into Types2 (Class1, Class2) values ('���͸�ʳ', 'ʳ����');
insert into Types2 (Class1, Class2) values ('����ϴ��', '���˻���');
insert into Types2 (Class1, Class2) values ('����ϴ��', '���ݻ���');
insert into Types2 (Class1, Class2) values ('�Ҿ���Ʒ', '����ֽ');
insert into Types2 (Class1, Class2) values ('�Ҿ���Ʒ', '����');

insert into Types3 (Class2, Class3) values ('ţ����Ʒ', '������');
insert into Types3 (Class2, Class3) values ('ţ����Ʒ', '����');
insert into Types3 (Class2, Class3) values ('�ǹ�', '�ɿ���');
insert into Types3 (Class2, Class3) values ('�ǹ�', '������');
insert into Types3 (Class2, Class3) values ('�ǹ�', '���');
insert into Types3 (Class2, Class3) values ('����', 'ˮ');
insert into Types3 (Class2, Class3) values ('����', '��������');
insert into Types3 (Class2, Class3) values ('����', '̼������');
insert into Types3 (Class2, Class3) values ('��������', '����');
insert into Types3 (Class2, Class3) values ('��������', 'ʳ����');
insert into Types3 (Class2, Class3) values ('ʳ����', '������');
insert into Types3 (Class2, Class3) values ('ʳ����', '������');
insert into Types3 (Class2, Class3) values ('���˻���', 'ϴ��ˮ');
insert into Types3 (Class2, Class3) values ('���ݻ���', '��Ĥ');
insert into Types3 (Class2, Class3) values ('����', '�˵�');

insert into Goods (Class3, GoodID) values ('������', '��������ţ��125ml*24��');
insert into Goods (Class3, GoodID) values ('������', '����ζ�����㽶ţ��240ml*12��');
insert into Goods (Class3, GoodID) values ('������', 'ζȫ���������435ml');
insert into Goods (Class3, GoodID) values ('������', 'άά���̷�560g/��');
insert into Goods (Class3, GoodID) values ('������', '�޹���пˬ����200ml*16/�����װ');
insert into Goods (Class3, GoodID) values ('������', '��ţ��ţ��1Lװ');
insert into Goods (Class3, GoodID) values ('������', '��������ţ��1.5L/ƿţ��');
insert into Goods (Class3, GoodID) values ('������', '�޹���Ӫ�����߹�֭ţ��ԭζ280ml/ƿ');
insert into Goods (Class3, GoodID) values ('�ɿ���', '�������ɿ���32��װ');
insert into Goods (Class3, GoodID) values ('�ɿ���', 'Ȥ���ԭζ����216g');
insert into Goods (Class3, GoodID) values ('�ɿ���', '�������ɿ˰�����20��');
insert into Goods (Class3, GoodID) values ('�ɿ���', '��ܽŷʽ�����ɿ���ζ192g');
insert into Goods (Class3, GoodID) values ('�ɿ���', '������Ƭ�����ɿ���ζ104g');
insert into Goods (Class3, GoodID) values ('�ɿ���', '������ܽ60g�ɿ���ζ');
insert into Goods (Class3, GoodID) values ('�ɿ���', '̨������ž���С�����ɿ�������Ȧ45g');
insert into Goods (Class3, GoodID) values ('�ɿ���', '������ţ���ɿ�������̫���ǹ�ԭζ��װ');
insert into Goods (Class3, GoodID) values ('��������', 'ũ��ɽȪˮ��C100����ζ445ml');
insert into Goods (Class3, GoodID) values ('��������', '��Դ100%��������������֭1L/ƿ');
insert into Goods (Class3, GoodID) values ('��������', '�����ζ��������װ�������400g');

insert into Inventory(GoodID, MarketName, Price) values('��������ţ��125ml*24��', '1�ŵ�', 100);
insert into Inventory(GoodID, MarketName, Price) values('����ζ�����㽶ţ��240ml*12��', '1�ŵ�', 100);
insert into Inventory(GoodID, MarketName, Price) values('ζȫ���������435ml', '1�ŵ�', 100);
insert into Inventory(GoodID, MarketName, Price) values('άά���̷�560g/��', '1�ŵ�', 100);
insert into Inventory(GoodID, MarketName, Price) values('�޹���пˬ����200ml*16/�����װ', '1�ŵ�', 100);
insert into Inventory(GoodID, MarketName, Price) values('��ţ��ţ��1Lװ', '1�ŵ�', 100);
insert into Inventory(GoodID, MarketName, Price) values('��������ţ��1.5L/ƿţ��', '1�ŵ�', 100);
insert into Inventory(GoodID, MarketName, Price) values('�޹���Ӫ�����߹�֭ţ��ԭζ280ml/ƿ', '1�ŵ�', 100);
insert into Inventory(GoodID, MarketName, Price) values('�������ɿ���32��װ', '1�ŵ�', 100);
insert into Inventory(GoodID, MarketName, Price) values('Ȥ���ԭζ����216g', '1�ŵ�', 100);
insert into Inventory(GoodID, MarketName, Price) values('��ܽŷʽ�����ɿ���ζ192g', '1�ŵ�', 100);


insert into Orders(GoodID, MarketName, UserID, Amount) values('��������ţ��125ml*24��', '1�ŵ�', 26, 1);
insert into Orders(GoodID, MarketName, UserID, Amount) values('����ζ�����㽶ţ��240ml*12��', '1�ŵ�', 26, 1);
insert into Orders(GoodID, MarketName, UserID, Amount) values('ζȫ���������435ml', '1�ŵ�', 26, 1);
insert into Orders(GoodID, MarketName, UserID, Amount) values('άά���̷�560g/��', '1�ŵ�', 26, 1);
insert into Orders(GoodID, MarketName, UserID, Amount) values('�޹���пˬ����200ml*16/�����װ', '1�ŵ�', 26, 1);
insert into Orders(GoodID, MarketName, UserID, Amount) values('��ţ��ţ��1Lװ', '1�ŵ�', 26, 1);
insert into Orders(GoodID, MarketName, UserID, Amount) values('��������ţ��1.5L/ƿţ��', '1�ŵ�', 26, 1);
insert into Orders(GoodID, MarketName, UserID, Amount) values('�޹���Ӫ�����߹�֭ţ��ԭζ280ml/ƿ', '1�ŵ�', 26, 1);
insert into Orders(GoodID, MarketName, UserID, Amount) values('�������ɿ���32��װ', '1�ŵ�', 26, 1);
insert into Orders(GoodID, MarketName, UserID, Amount) values('Ȥ���ԭζ����216g', '1�ŵ�', 26, 1);
insert into Orders(GoodID, MarketName, UserID, Amount) values('��ܽŷʽ�����ɿ���ζ192g', '1�ŵ�', 26, 1);

