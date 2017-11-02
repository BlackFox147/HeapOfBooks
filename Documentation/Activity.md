### Добавить коллекцию

Цель: Добавить новую коллекцию  
Главная последовательность:  
1. пользователь нажимает на кнопку добавления коллекции;
2. система запрашивает у пользователя имя новой коллекции;
3. пользователь вводит желаемое имя;
4. система добавляет коллекцию;
5. новая коллекция отображается вместе с остальными.

### Удалить коллекцию

Цель: Удалить существующую коллекцию   
Предусловие: коллекция должна существовать  
Главная последовательность:  
1. пользователь нажимает на кнопку удаления коллекции;
2. система запрашивает у пользователя подтверждение;
3. пользователь подтверждает действие. При отмене действия переход к альтернативной последовательности A1;
4. система удаляет коллекцию;

Альтернативная последовательность А1:  
1. система не удаляет коллекцию;


### Просмотреть коллекцию

Цель: Отобразить в центральной части окна содержание коллекции, т.е. список входящих в неё документов и краткую информацию о них.   
Предусловие: коллекция должна существовать  
Главная последовательность:  
1. пользователь выбирает нужную коллекцию;
2. система отображает содержание коллекции.

### Добавить документ

Цель: Добавить новую коллекцию  
Предусловие: коллекция должна быть выбрана
Главная последовательность:  
1. пользователь нажимает на кнопку добавления документа;
2. система запрашивает у пользователя информацию о новом документа: месторасположение документа на персональном компьютере (путь к документу), тип(рабочий документ, книга);
3. пользователь вводит требуемые данные;
4. система добавляет файл в коллекцию;
5. новый документ отображается вместе со всеми документами коллекции.

### Уделить документ

Цель: Добавить новую коллекцию  
Предусловие:
- коллекция должна быть выбрана;  
- документ должен существовать и быть выбран.

Главная последовательность:  
1. пользователь нажимает на кнопку удаления документа;
2. система запрашивает у пользователя подтверждение;
3. пользователь подтверждает действие. При отмене действия переход к альтернативной последовательности A1;
4. система удаляет документ;

Альтернативная последовательность А1:  
1. система не удаляет документ;

### Открыть документ средствами операционной системы

Цель: Открыть выбранный для просмотра/редактирования  
Предусловие:
- коллекция должна быть выбрана;  

Главная последовательность:
1. пользователь выбирает требуемый документ;
2. система передаёт путь к документу средствами операционной системы;
3. поиск реального документа на персональном компьютере. Если не найден, то переход к альтернативной последовательности А1;
4. открытие документа;

Альтернативная последовательность А1:  
1. система выдаёт сообщение, что документ не найден;

<a name="search"></a>
### Поиск

Цель: Нахождение документов или коллекций по названию  

Главная последовательность:
1. пользователь вводит информацию для поиска;
2. система ищет совпадения в базе данных;
3. система отображает результат;

### Изменить информацию о документе

Цель: Изменение существующей информации о конкретном документе
Предусловие:
- коллекция должна быть выбрана;   

Главная последовательность:
1. выбрать документ;
2. система откроет окно с информацией о документе;
3. пользователь изменяет необходимую информацию;
4. система сохраняет изменение;

### Добавить комментарий

Цель: Добавить новый комментарий
Предусловие:
- коллекция должна быть выбрана;
- документ должен быть выбран.
Главная последовательность:  
1. пользователь нажимает на кнопку добавления комментария;
2. система добавляет комментарий;
3. новый комментарий отображается вместе со всеми.

### Уделить комментарий

Цель: Удалить комментарий новую коллекцию  
Предусловие:
- коллекция должна быть выбрана;  
- документ должен существовать и быть выбран.

Главная последовательность:  
1. пользователь нажимает на кнопку удаления комментария;
2. система запрашивает у пользователя подтверждение;
3. пользователь подтверждает действие. При отмене действия переход к альтернативной последовательности A1;
4. система удаляет документ;

Альтернативная последовательность А1:  
1. система не удаляет документ;

### Изменить комментарий

Цель: Изменение существующей комментарий
Предусловие:
- коллекция должна быть выбрана;  
- документ должен существовать и быть выбран.

Главная последовательность:
1. выбрать комментарий;
2. нажать на кнопку изменения комментария;
3. правка текста существующего комментария;
4. сохранение комментария.