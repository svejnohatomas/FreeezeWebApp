USE [master];

IF EXISTS(SELECT * FROM sys.databases WHERE name='dbFreeeze')
BEGIN
	ALTER DATABASE [dbFreeeze] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
	DROP DATABASE [dbFreeeze];
END
CREATE DATABASE [dbFreeeze];
GO

USE [dbFreeeze];
CREATE TABLE fz_tbBlogArticle(
	ID int identity(1,1) not null primary key,
	ARTICLE_NAME nvarchar(64) not null,
	ARTICLE_ADDED_ON_UTC datetime not null default GETUTCDATE(),
	IDfz_tbEditors int not null,
	ARTICLE_TEASER nvarchar(1024) not null,
	ARTICLE_CONTENT nvarchar(max) not null,
	ARTICLE_IMAGE_PATH nvarchar(2048) not null,
	ARTICLE_IMAGE_ALT nvarchar(256) not null
);

CREATE TABLE fz_tbContactFormResponse(
	ID int identity(1,1) not null primary key,
	RESPONSE_NAME nvarchar(32) not null,
	RESPONSE_EMAIL nvarchar(512) not null,
	RESPONSE_SUBJECT nvarchar(64) not null,
	RESPONSE_MESSAGE nvarchar(max) not null,
	RESPONSE_ADDED_ON_UTC datetime not null default GETUTCDATE()
);

CREATE TABLE fz_tbEditors(
	ID int identity(1,1) not null primary key,
	FIRST_NAME nvarchar(64) not null,
	MIDDLE_NAME nvarchar(64),
	LAST_NAME nvarchar(64) not null,
	USERNAME nvarchar(64) not null,
	PSWD_HASH nvarchar(2048) not null,
	PSWD_SALT nvarchar(2048) not null,
	REGISTERED_ON_UTC datetime not null default GETUTCDATE()
);

CREATE TABLE fz_tbLogins(
	ID int identity(1,1) not null primary key,
	IDfz_tbEditors int not null,
	LOGIN_TIME_UTC datetime not null default GETUTCDATE(),
	LOGOUT_TIME_UTC datetime not null default DATEADD(mi, 20, GETUTCDATE()),
	USER_AGENT nvarchar(256) not null,
	USER_IP nvarchar(15) not null
);

CREATE TABLE fz_tbProducts(
	ID int identity(1,1) not null primary key,
	PRODUCT_NAME nvarchar(64) not null,
	PRODUCT_DESCRIPTION nvarchar(512) not null
);

CREATE TABLE fz_tbProductVariants(
	ID int identity(1,1) not null primary key,
	IDfz_tbProducts int not null,
	VARIANT_NAME nvarchar(64) not null,
	VARIANT_IMAGE_PATH nvarchar(2048) not null,
	VARIANT_IMAGE_ALT nvarchar(256) not null
);

ALTER TABLE fz_tbBlogArticle ADD CONSTRAINT FK_fz_tbBlogArticle_IDfz_tbEditors FOREIGN KEY (IDfz_tbEditors) REFERENCES fz_tbEditors(ID);
ALTER TABLE fz_tbLogins ADD CONSTRAINT FK_fz_tbLogins_IDfz_tbEditors FOREIGN KEY (IDfz_tbEditors) REFERENCES fz_tbEditors(ID);
ALTER TABLE fz_tbProductVariants ADD CONSTRAINT FK_fz_tbProductVariants_IDfz_tbProducts FOREIGN KEY (IDfz_tbProducts) REFERENCES fz_tbProducts(ID);

INSERT INTO fz_tbEditors (FIRST_NAME, LAST_NAME, USERNAME, PSWD_HASH, PSWD_SALT)
VALUES ('Default', 'User', 'root', '3C0B12EE65D62246A687DBDC03D59125EA436C949FE7571E2BBA1F0F09C819646C61EDBC322C09074EA8AA9FB2ABF5ACC0B6CF3E9013F1D134ABEE9572A96F1B', 'RqlI4WxgnlVqFmwXhr03')

INSERT INTO fz_tbBlogArticle (ARTICLE_NAME, IDfz_tbEditors, ARTICLE_TEASER, ARTICLE_CONTENT, ARTICLE_IMAGE_PATH, ARTICLE_IMAGE_ALT) VALUES (
'NEW CHILLS FOR SUMMER',
1,
'This website template has been designed by Free Website Templates for you, for free. You can replace all this text with your own text. Want an easier solution for a Free Website? Head straight to Wix and immediately start customizing your website! Wix is an online website builder with a simple drag & drop interface, meaning you do the work online and instantly publish to the web. Nothing to download, nothing to upload. All Wix templates are fully customizable and free to use. Just pick one you like, click Edit, and enter the online editor. Change, add, and remove items as you like.',
'This website template has been designed by Free Website Templates for you, for free. You can replace all this text with your own text. Want an easier solution for a Free Website? Head straight to Wix and immediately start customizing your website! Wix is an online website builder with a simple drag & drop interface, meaning you do the work online and instantly publish to the web. Nothing to download, nothing to upload. All Wix templates are fully customizable and free to use. Just pick one you like, click Edit, and enter the online editor. Change, add, and remove items as you like.</p><p>Want an easier solution for a Free Website? Head straight to Wix and immediately start customizing your website! Wix is an online website builder with a simple drag & drop interface, meaning you do the work online and instantly publish to the web. Nothing to download, nothing to upload. All Wix templates are fully customizable and free to use. Just pick one you like, click Edit, and enter the online editor. Change, add, and remove items as you like. Wix also offers a ton of free design elements right inside the editor, like images, icons, animation files, and interactive widgets. Publish your Free Website in minutes!',
'/Content/images/new-chills.png',
'Strawberry image');
INSERT INTO fz_tbBlogArticle (ARTICLE_NAME, IDfz_tbEditors, ARTICLE_TEASER, ARTICLE_CONTENT, ARTICLE_IMAGE_PATH, ARTICLE_IMAGE_ALT) VALUES (
'BERRIES ON THE GROVE',
1,
'This website template has been designed by Free Website Templates for you, for free. You can replace all this text with your own text. This website template has been designed by Free Website Templates for you, for free. You can replace all this text with your own text. This website template has been designed by Free Website Templates for you, for free. You can replace all this text with your own text. This website template has been designed by Free Website Templates for you, for free. You can replace all this text with your own text.',
'This website template has been designed by Free Website Templates for you, for free. You can replace all this text with your own text. Want an easier solution for a Free Website? Head straight to Wix and immediately start customizing your website! Wix is an online website builder with a simple drag & drop interface, meaning you do the work online and instantly publish to the web. Nothing to download, nothing to upload. All Wix templates are fully customizable and free to use. Just pick one you like, click Edit, and enter the online editor. Change, add, and remove items as you like.</p><p>Want an easier solution for a Free Website? Head straight to Wix and immediately start customizing your website! Wix is an online website builder with a simple drag & drop interface, meaning you do the work online and instantly publish to the web. Nothing to download, nothing to upload. All Wix templates are fully customizable and free to use. Just pick one you like, click Edit, and enter the online editor. Change, add, and remove items as you like. Wix also offers a ton of free design elements right inside the editor, like images, icons, animation files, and interactive widgets. Publish your Free Website in minutes!',
'/Content/images/berries.png',
'Berries image');
INSERT INTO fz_tbBlogArticle (ARTICLE_NAME, IDfz_tbEditors, ARTICLE_TEASER, ARTICLE_CONTENT, ARTICLE_IMAGE_PATH, ARTICLE_IMAGE_ALT) VALUES (
'ON THE DIET',
1,
'This is just a place holder, so you can see what the site would look like.',
'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Pellentesque pretium lectus id turpis. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Maecenas fermentum, sem in pharetra pellentesque, velit turpis volutpat ante, in pharetra metus odio a lectus. Etiam egestas wisi a erat. Fusce consectetuer risus a nunc. Aenean id metus id velit ullamcorper pulvinar. Sed ac dolor sit amet purus malesuada congue. Maecenas aliquet accumsan leo. Aliquam erat volutpat. Nemo enim ipsam voluptatem quia voluptas sit aspernatur aut odit aut fugit, sed quia consequuntur magni dolores eos qui ratione voluptatem sequi nesciunt. Ut enim ad minima veniam, quis nostrum exercitationem ullam corporis suscipit laboriosam, nisi ut aliquid ex ea commodi consequatur? Sed elit dui, pellentesque a, faucibus vel, interdum nec, diam. Integer in sapien. Duis ante orci, molestie vitae vehicula venenatis, tincidunt ac pede. Integer vulputate sem a nibh rutrum consequat.',
'/Content/images/on-diet.png',
'On diet image');

INSERT INTO fz_tbProducts (PRODUCT_NAME, PRODUCT_DESCRIPTION) VALUES ('All Time Classic', 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas libero. Morbi imperdiet, mauris ac auctor dictum, nisl ligula egestas...');
INSERT INTO fz_tbProducts (PRODUCT_NAME, PRODUCT_DESCRIPTION) VALUES ('Berry Special', 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas libero. Morbi imperdiet, mauris ac auctor dictum, nisl ligula egestas...');
INSERT INTO fz_tbProducts (PRODUCT_NAME, PRODUCT_DESCRIPTION) VALUES ('Fruit Blast', 'Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Maecenas libero. Morbi imperdiet, mauris ac auctor dictum, nisl ligula egestas...');

INSERT INTO fz_tbProductVariants (IDfz_tbProducts, VARIANT_NAME, VARIANT_IMAGE_PATH, VARIANT_IMAGE_ALT) VALUES (1, 'KIWI', '/Content/images/kiwi.jpg', 'Kiwi image');
INSERT INTO fz_tbProductVariants (IDfz_tbProducts, VARIANT_NAME, VARIANT_IMAGE_PATH, VARIANT_IMAGE_ALT) VALUES (1, 'MANGO', '/Content/images/mango.jpg', 'Mango image');
INSERT INTO fz_tbProductVariants (IDfz_tbProducts, VARIANT_NAME, VARIANT_IMAGE_PATH, VARIANT_IMAGE_ALT) VALUES (1, 'CANTALOUPE', '/Content/images/cantaloupe.jpg', 'Cantaloupe image');

INSERT INTO fz_tbProductVariants (IDfz_tbProducts, VARIANT_NAME, VARIANT_IMAGE_PATH, VARIANT_IMAGE_ALT) VALUES (2, 'BLACKBERRY', '/Content/images/blackberry.jpg', 'Blackberry image');
INSERT INTO fz_tbProductVariants (IDfz_tbProducts, VARIANT_NAME, VARIANT_IMAGE_PATH, VARIANT_IMAGE_ALT) VALUES (2, 'STRAWBERRY', '/Content/images/strawberry.jpg', 'Strawberry image');
INSERT INTO fz_tbProductVariants (IDfz_tbProducts, VARIANT_NAME, VARIANT_IMAGE_PATH, VARIANT_IMAGE_ALT) VALUES (2, 'BLUEBERRY', '/Content/images/blueberry.jpg', 'Blueberry image');

INSERT INTO fz_tbProductVariants (IDfz_tbProducts, VARIANT_NAME, VARIANT_IMAGE_PATH, VARIANT_IMAGE_ALT) VALUES (3, 'GRAPES', '/Content/images/grapes.jpg', 'Grapes image');
INSERT INTO fz_tbProductVariants (IDfz_tbProducts, VARIANT_NAME, VARIANT_IMAGE_PATH, VARIANT_IMAGE_ALT) VALUES (3, 'GREEN APPLE', '/Content/images/green-apple.jpg', 'Green apple image');
INSERT INTO fz_tbProductVariants (IDfz_tbProducts, VARIANT_NAME, VARIANT_IMAGE_PATH, VARIANT_IMAGE_ALT) VALUES (3, 'PINEAPPLE', '/Content/images/pineapple.jpg', 'Pineapple image');

SELECT * FROM fz_tbEditors;
SELECT * FROM fz_tbBlogArticle;
SELECT * FROM fz_tbProducts;
SELECT * FROM fz_tbProductVariants;