CREATE TABLE migration(
    id BIGINT,
    name VARCHAR(30) 
        CONSTRAINT uq_migration_name UNIQUE 
        CONSTRAINT nn_migration_name NOT NULL
);

CREATE TABLE grape (
    id BIGINT PRIMARY KEY,
    name VARCHAR(50) 
        CONSTRAINT uq_grape_name UNIQUE
        CONSTRAINT nn_grape_name NOT NULL
);

CREATE TABLE wine (
  id BIGINT PRIMARY KEY,
  producer VARCHAR(255)
    CONSTRAINT uq_wine_producer UNIQUE
    CONSTRAINT nn_wine_producer NOT NULL,
  label VARCHAR(255)
    CONSTRAINT uq_wine_label UNIQUE
    CONSTRAINT nn_wine_label NOT NULL,
  vintage DATE,
  alcohol_by_volume decimal
    CONSTRAINT nn_wine_alcoholbyvolume NOT NULL,
  container varchar(30)
    CONSTRAINT nn_wine_container NOT NULL
); 

CREATE TABLE blend(
    wine_id integer REFERENCES wine
      CONSTRAINT nn_wine_id NOT NULL,
    grape_id integer REFERENCES grape
      CONSTRAINT nn_grape_id NOT NULL,
    percentage int
      CONSTRAINT nn_blend_percentage NOT NULL,

    PRIMARY KEY (wine_id, grape_id, percentage)
);