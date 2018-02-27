//Configuring Cascade Deletes
//Defining relationships using the fluent API can be confusing, so don't worry if this walkthrough doesn't make complete sense the first time that you see it.With practice—and access to good documentation—you'll be able to work your way through it.

//modelBuilder.Entity<ComicBookArtist>()
//    .HasRequired(cba => cba.ComicBook)
//    .WithMany(cb => cb.Artists)
//    .HasForeignKey(cba => cba.ComicBookId)
//    .WillCascadeOnDelete(false);
//First, we need to get a reference to the ComicBookArtist entity in our model by making a call to the model builder's Entity method.

//modelBuilder.Entity<ComicBookArtist>()
//Then we can use the HasRequired method to configure the relationship between the ComicBookArtist and ComicBook entities.

//.HasRequired(cba => cba.ComicBook)
//By using the HasRequired method, we're making the relationship required, which makes sense in this case as a ComicBookArtist bridge entity needs to be associated with a comic book.

//The HasRequired method returns an object that allows us to configure the other side of the relationship.Since a comic book can be associated with "many" artists, we'll use the WithMany method.

//.WithMany(cb => cb.Artists)
//Then the WithMany method returns an object that allows us to configure the dependent navigation property on the ComicBookArtist entity.This allows us to configure a foreign key property for the relationship by calling the HasForeignKey method.

//.HasForeignKey(cba => cba.ComicBookId)
//And finally, the HasForeignKey method returns an object that allows us to configure the cascade delete behavior.

//.WillCascadeOnDelete(false);
//By passing in "false" to the WillCascadeOnDelete method, we're disabling the cascade behavior for this relationship.

//Now if we tried to delete a ComicBook entity from the app, we'd get a runtime exception, because a child or dependent ComicBookArtist entity has a reference to the entity that we're trying to delete.To successfully delete the ComicBook entity, we'd need to first delete any ComicBookArtist entities that are associated with that entity.

//It's also possible to globally disable cascade deletes by removing the pertinent EF conventions.

//modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
//modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
//Now cascade deletes would be disabled for all of our relationships.We can still override this convention of course, by defining a relationship using the fluent API and manually enabling cascade deletes.