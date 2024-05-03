### FigureAreaCalculator
#### Библиотека для поставки внешним клиентам, которая умеет вычислять площадь круга по радиусу и треугольника по трем сторонам.

Вопрос №3: 

В базе данных MS SQL Server есть продукты и категории. Одному продукту может соответствовать много категорий, в одной категории может быть много продуктов. Напишите SQL запрос для выбора всех пар «Имя продукта – Имя категории». Если у продукта нет категорий, то его имя все равно должно выводиться.

Ответ:
Для решения необходимо создать вспомогательную промежуточную таблицу
```
CREATE TABLE ProductsCategories (
    ProductId INT,
    CategoryId INT,
    FOREIGN KEY (ProductId) REFERENCES Products(Id),
    FOREIGN KEY (CategoryId) REFERENCES Categories(Id),
    PRIMARY KEY (ProductId, CategoryId)
)
```
Через нее делаем итоговую выборку пар «Имя продукта – Имя категории»
```
SELECT p.Name as ProductName, ISNULL(c.Name, 'Без категории') AS CategoryName
FROM Products p
LEFT JOIN ProductsCategories pc ON pc.ProductId = p.Id 
LEFT JOIN Categories c ON pc.CategoryId = c.Id
```
