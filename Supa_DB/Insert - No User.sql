/* Delete old data */
delete from Orders;
delete from Inventory;
delete from Goods;
delete from Types3;
delete from Types2;
delete from Types1;
delete from Markets;

/* Insert data */
insert into Markets (MarketName, MarketAdd, MarketEst) values ('1号店', '思贤楼', '5');
insert into Markets (MarketName, MarketAdd, MarketEst) values ('2号店', '明德楼', '5');

insert into Types1 (Class1) values ('食品饮料');
insert into Types1 (Class1) values ('粮油副食');
insert into Types1 (Class1) values ('美容洗护');
insert into Types1 (Class1) values ('家居用品');

insert into Types2 (Class1, Class2) values ('食品饮料', '牛奶乳品');
insert into Types2 (Class1, Class2) values ('食品饮料', '糖果');
insert into Types2 (Class1, Class2) values ('食品饮料', '饮料');
insert into Types2 (Class1, Class2) values ('粮油副食', '厨房调料');
insert into Types2 (Class1, Class2) values ('粮油副食', '食用油');
insert into Types2 (Class1, Class2) values ('美容洗护', '个人护理');
insert into Types2 (Class1, Class2) values ('美容洗护', '美容护肤');
insert into Types2 (Class1, Class2) values ('家居用品', '卫生纸');
insert into Types2 (Class1, Class2) values ('家居用品', '厨具');

insert into Types3 (Class2, Class3) values ('牛奶乳品', '常温奶');
insert into Types3 (Class2, Class3) values ('牛奶乳品', '酸奶');
insert into Types3 (Class2, Class3) values ('糖果', '巧克力');
insert into Types3 (Class2, Class3) values ('糖果', '口香糖');
insert into Types3 (Class2, Class3) values ('糖果', '坚果');
insert into Types3 (Class2, Class3) values ('饮料', '水');
insert into Types3 (Class2, Class3) values ('饮料', '果蔬饮料');
insert into Types3 (Class2, Class3) values ('饮料', '碳酸饮料');
insert into Types3 (Class2, Class3) values ('厨房调料', '酱油');
insert into Types3 (Class2, Class3) values ('厨房调料', '食用盐');
insert into Types3 (Class2, Class3) values ('食用油', '调和油');
insert into Types3 (Class2, Class3) values ('食用油', '花生油');
insert into Types3 (Class2, Class3) values ('个人护理', '洗发水');
insert into Types3 (Class2, Class3) values ('美容护肤', '面膜');
insert into Types3 (Class2, Class3) values ('厨具', '菜刀');

insert into Goods (Class3, GoodID) values ('常温奶', '旺旺旺仔牛奶125ml*24盒');
insert into Goods (Class3, GoodID) values ('常温奶', '伊利味可滋香蕉牛奶240ml*12盒');
insert into Goods (Class3, GoodID) values ('常温奶', '味全乳酸菌饮料435ml');
insert into Goods (Class3, GoodID) values ('常温奶', '维维豆奶粉560g/袋');
insert into Goods (Class3, GoodID) values ('常温奶', '娃哈哈锌爽歪歪200ml*16/箱礼盒装');
insert into Goods (Class3, GoodID) values ('常温奶', '蒙牛纯牛奶1L装');
insert into Goods (Class3, GoodID) values ('常温奶', '光明纯鲜牛奶1.5L/瓶牛奶');
insert into Goods (Class3, GoodID) values ('常温奶', '娃哈哈营养快线果汁牛奶原味280ml/瓶');
insert into Goods (Class3, GoodID) values ('巧克力', '费列罗巧克力32粒装');
insert into Goods (Class3, GoodID) values ('巧克力', '趣多多原味饼干216g');
insert into Goods (Class3, GoodID) values ('巧克力', '奥利奥巧克棒威化20条');
insert into Goods (Class3, GoodID) values ('巧克力', '妙芙欧式蛋糕巧克力味192g');
insert into Goods (Class3, GoodID) values ('巧克力', '乐事薯片海盐巧克力味104g');
insert into Goods (Class3, GoodID) values ('巧克力', '旺旺泡芙60g巧克力味');
insert into Goods (Class3, GoodID) values ('巧克力', '台湾进口张君雅小妹妹巧克力甜甜圈45g');
insert into Goods (Class3, GoodID) values ('巧克力', '怡口莲牛奶巧克力夹心太妃糖果原味罐装');
insert into Goods (Class3, GoodID) values ('果蔬饮料', '农夫山泉水溶C100柠檬味445ml');
insert into Goods (Class3, GoodID) values ('果蔬饮料', '汇源100%纯果蔬饮料葡萄汁1L/瓶');
insert into Goods (Class3, GoodID) values ('果蔬饮料', '果珍果味冲饮壶嘴装阳光甜橙400g');

insert into Inventory(GoodID, MarketName, Price) values('旺旺旺仔牛奶125ml*24盒', '1号店', 100);
insert into Inventory(GoodID, MarketName, Price) values('伊利味可滋香蕉牛奶240ml*12盒', '1号店', 100);
insert into Inventory(GoodID, MarketName, Price) values('味全乳酸菌饮料435ml', '1号店', 100);
insert into Inventory(GoodID, MarketName, Price) values('维维豆奶粉560g/袋', '1号店', 100);
insert into Inventory(GoodID, MarketName, Price) values('娃哈哈锌爽歪歪200ml*16/箱礼盒装', '1号店', 100);
insert into Inventory(GoodID, MarketName, Price) values('蒙牛纯牛奶1L装', '1号店', 100);
insert into Inventory(GoodID, MarketName, Price) values('光明纯鲜牛奶1.5L/瓶牛奶', '1号店', 100);
insert into Inventory(GoodID, MarketName, Price) values('娃哈哈营养快线果汁牛奶原味280ml/瓶', '1号店', 100);
insert into Inventory(GoodID, MarketName, Price) values('费列罗巧克力32粒装', '1号店', 100);
insert into Inventory(GoodID, MarketName, Price) values('趣多多原味饼干216g', '1号店', 100);
insert into Inventory(GoodID, MarketName, Price) values('妙芙欧式蛋糕巧克力味192g', '1号店', 100);


insert into Orders(GoodID, MarketName, UserID, Amount) values('旺旺旺仔牛奶125ml*24盒', '1号店', 26, 1);
insert into Orders(GoodID, MarketName, UserID, Amount) values('伊利味可滋香蕉牛奶240ml*12盒', '1号店', 26, 1);
insert into Orders(GoodID, MarketName, UserID, Amount) values('味全乳酸菌饮料435ml', '1号店', 26, 1);
insert into Orders(GoodID, MarketName, UserID, Amount) values('维维豆奶粉560g/袋', '1号店', 26, 1);
insert into Orders(GoodID, MarketName, UserID, Amount) values('娃哈哈锌爽歪歪200ml*16/箱礼盒装', '1号店', 26, 1);
insert into Orders(GoodID, MarketName, UserID, Amount) values('蒙牛纯牛奶1L装', '1号店', 26, 1);
insert into Orders(GoodID, MarketName, UserID, Amount) values('光明纯鲜牛奶1.5L/瓶牛奶', '1号店', 26, 1);
insert into Orders(GoodID, MarketName, UserID, Amount) values('娃哈哈营养快线果汁牛奶原味280ml/瓶', '1号店', 26, 1);
insert into Orders(GoodID, MarketName, UserID, Amount) values('费列罗巧克力32粒装', '1号店', 26, 1);
insert into Orders(GoodID, MarketName, UserID, Amount) values('趣多多原味饼干216g', '1号店', 26, 1);
insert into Orders(GoodID, MarketName, UserID, Amount) values('妙芙欧式蛋糕巧克力味192g', '1号店', 26, 1);

