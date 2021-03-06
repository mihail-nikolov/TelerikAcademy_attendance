<h1>Creational patterns homework</h1>

<h2>Singleton</h2>

<ul>		
<li> Основната идея на Singleton шаблона е singleton класа е той да има точно 1 инстанция, чрез която да се използва и да се достъпва глобално.</li>
<li> Целта е спестяване на ресурси и време за инициализация.</li>
<li> Начина за използване на шаблона е самия клас да има метод, който инициализира класа (или да връща референция към обекта, ако вече е инициализиан).</li>
<li> В този случай трябва да има поле/метод, което да пази инстанцията на класа -> от тука възниква и 1 от проблемите -
 нарушава се Single responsibility principle:</li>
 	<ul>
     <li> от една страна класа се ползва, за функционалността е предназначен</li>
     <li> от друга страна класа пази своята единствена инстанция (ако тя вече съществува)</li>
     </ul>
<li> За да е сигурно, че класа няма да бъде инстанциран отвън конструктора се прави private.</li>
<li> Друг проблем е, че класа трябва да бъде внимателно конструиран при multi-theading applications.</li>
<li> Класа е труден за тестване.
</ul>

<h2>Abstract factory</h2>
<ul>
<li>Abstract factory pattern-a предоставя интерфейс за създаване на взаимносвързани обекти.</li>
<li>Factory само по себе си представлява метод за създаване на обекти, като идеята е бъде изолирано създаването от използването на конкретните обекти.</li>
<li>Abstract factory class-a капсулира група от методи Factroy с близко предназначение. </li>
По този начин на клиента не му е нужно да знае как се ползва всеки клас поотделно.Той използва само основния интерфейс.(Клиента не го интересува коя пицария ще му направи пицата, той просто я иска доставена :).</li>
<li>Abstract factory pattern-a позволява замяната на конкретни класове, дори по време на изпълнение, без да е нужна промяна на кода, който ги използва. 
Това обаче е за сметка на допълнително усложняване на кода, което от своя страна не е много желателно.</li>
</ul>

#Builder
<ul>
<li>Използва се, когато има многостъпково създаване на обект и последователността на тези стъпки е важна.</li>
<li>Работи се с "director", който знае за логиката, стъпките на създаване на отделните части на обекта. Director-а работи с "builder interface".</li>
<li>Самия "director" не го интересува какво точно се случва във всяка от тези стъпки - за това знае "concrete builder" (той ги имплементира), a "builder interface" ги дефинира.</li>
<li>Имаме разделяне на отговорности.</li>
</ul>