CREATE TABLE migration(
    id BIGINT,
    name VARCHAR(30)
);

CREATE TABLE grape (
    id BIGINT PRIMARY KEY,
    name VARCHAR(50)
);

CREATE TABLE wine (
  id BIGINT PRIMARY KEY,
  maker VARCHAR(255),
  model VARCHAR(255),
  vintage DATE
); 

CREATE TABLE Blend(
    wine_id integer REFERENCES wine,
    grape_id integer REFERENCES grape,
    percentage int
);