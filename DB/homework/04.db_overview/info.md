<h1>DB overview</h1>

<h2> What database models do you know?</h2>
<ul>		
	<li>Network Model </li>
	<li>Hierarchical Model</li>
	<li>Relational Model</li>
	<li>Object-oriented Model</li>
	<li>Object-relational Model</li>
</ul>


<h2> Which are the main functions performed by a Relational Database Management System (RDBMS)?</h2>
<ul>		
	<li> Creating / altering / deleting tables and relationships between them</li>
	<li> Adding, changing, deleting, searching and retrieving of data stored in the tables</li>
</ul>


<h2> Define what is "table" in database terms.</h2>
<ul>		
	<li> A table is a collection of related data held in a structured format within a database. It consists of fields (columns), and rows.</li>
</ul>


<h2>Explain the different kinds of relationships between tables in relational databases.</h2>
<h3>Primary key.</h3>
<ul>		
	<li>uniquely identify a record in the table.</li>
	<li>can't accept null values.</li>
	<li>By default, Primary key is clustered index.</li>
	<li>We can have only one Primary key in a table</li>
</ul>
<h3>Foreign key</h3>
<ul>		
	<li>it is a field in the table that is primary key in another table.</li>
	<li>can accept multiple null value.</li>
	<li>do not automatically create an index. You can manually create an index on foreign key.</li>
	<li>We can have more than one foreign key in a table.</li>
</ul>


<h2> When is a certain database schema normalized?
    What are the advantages of normalized databases?
</h2>
<ul>		
	<li>When the table is reduced to smaller tables without losing information; defining foreign keys in the old table referencing the primary keys of the new ones.</li>
<h3>Advantages</h3>
<ul>		
	<li>Provide indexing</li>
	<li>Reduce table/row size</li>
	<li>isolating data so that additions, deletions, and modifications of an attribute can be made in just one table.</li>
</ul>
</ul>


<h2> What are database integrity constraints and when are they used?</h2>
<ul>		
	<li>the rules enforced on data columns on table.This ensures the accuracy and reliability of the data in the database.</li>
	<li>They are used to limit the type of data that can go into a table. </li>
</ul>


<h2> Point out the pros and cons of using indexes in a database.</h2>
<h3>Pros</h3>
<ul>		
	<li> for quick access to a database table specific information.</li>
	<li> As a general rule, only when the data in the index column Frequent queries, only need to create an index on the table.</li>
	<li> Used in bigger tables</li>
</ul>
<h3>Cons</h3>
<ul>		
	<li> affect the speed of update and insert, because it requires the same update each index file.</li>
	<li> For a frequently updated and inserted into the table, there is no need for a rarely used where the words indexed separately, small table, the cost of sorting will not be great, there is no need to create additional indexes.</li>
	<li>The index take up disk space</li>
</ul>


<h2>What's the main purpose of the SQL language?</h2>
<ul>		
	<li>managing data held in a RDBMS, or for stream processing in a RDSMS</li>
</ul>


<h2>  What are transactions used for?
    Give an example.
</h2>
<ul>		
	<li>Transactional control commands are only used with the DML commands INSERT, UPDATE and DELETE only.</li>
	<li>They can not be used while creating tables or dropping them because these operations are automatically commited in the database.</li>
	<li>DELETE FROM CUSTOMERS
     	WHERE AGE = 25;
	 	COMMIT;
	 </li>
	
</ul>


<h2>What is a NoSQL database?</h2>
<ul>		
	<li> provides a mechanism for storage and retrieval of data that is modeled in means other than the tabular relations used in relational databases. </li>
	<li> </li>
</ul>


<h2>Explain the classical non-relational data models</h2>
<ul>		
	<li>a database that does not incorporate the table/key model that relational database management systems (RDBMS) promote. </li>
	<li> </li>
</ul>


<h2> Give few examples of NoSQL databases and their pros and cons.</h2>
<ul>		
	<li>Key value pairs</li>
	<li>Set of documents - JSON</li>
	<li>Hierarchy of key-value pairs</li>
</ul>
<h3>Pros</h3>
<ul>		
	<li>Elastic scaling - NoSQL databases are designed to expand transparently to take advantage of new nodes, and they're usually designed with low-cost commodity hardware in mind.</li>
	<li>NoSQL databases are generally designed from the ground up to require less management:  automatic repair, data distribution, and simpler data models lead to lower administration and tuning requirements — in theory.</li>
	<li>Flexible data models</li>
	<li>the cost per gigabyte or transaction/second for NoSQL can be many times less than the cost for RDBMS</li>
</ul>
<h3>Cons</h3>
<ul>		
	<li> Support -  most NoSQL systems are open source projects, and although there are usually one or more firms offering support for each NoSQL database,</li>
	<li> FAnalytics and business intelligence - NoSQL databases offer few facilities for ad-hoc query and analysis</li>
	<li>Administration -  NoSQL today requires a lot of skill to install and a lot of effort to maintain.</li>
</ul>



