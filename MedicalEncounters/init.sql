-- Create Facilities table
CREATE TABLE facilities (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255),
    city VARCHAR(255)
);

-- Insert facilities
INSERT INTO facilities (name, city) VALUES
    ('Facility 1', 'Medellín'),
    ('Facility 2', 'Envigado'),
    ('Facility 3', 'Sabaneta');

-- Create patients table
CREATE TABLE patients (
    id SERIAL PRIMARY KEY,
    first_name VARCHAR(255),
    last_name VARCHAR(255),
    age INTEGER
);

-- Insert patients
INSERT INTO patients (first_name, last_name, age) VALUES
    ('Felipe', 'Zapata', 38),
    ('Diego', 'Zapata', 64),
    ('Matias', 'Zapata', 3),
    ('Karol', 'Ortega', 39),
    ('Jacobo', 'Zapata', 1);

-- Create payers table
CREATE TABLE payers (
    id SERIAL PRIMARY KEY,
    name VARCHAR(255),
    city VARCHAR(255)
);

-- Insert payers
INSERT INTO payers (name, city) VALUES
    ('Payer 1', 'Medellín'),
    ('Payer 2', 'Bogotá'),
    ('Payer 3', 'Cali'),
    ('Payer 4', 'Cali');

-- Create encounters table
CREATE TABLE encounters (
    id SERIAL PRIMARY KEY,
    patient_id INTEGER REFERENCES patients(id),
    facility_id INTEGER REFERENCES facilities(id),
    payer_id INTEGER REFERENCES payers(id)
);

-- Insert test data
INSERT INTO encounters (patient_id, facility_id, payer_id) VALUES
    (1, 1, 1),  -- Felipe visited Facility 1, Payer 1 
    (1, 2, 2),  -- Felipe visited Facility 2, Payer 2
    (2, 3, 3),  -- Diego visited Facility 3, Payer 3 
    (3, 1, 3),  -- Matías visited Facility 1, Payer 3
    (3, 2, 4),  -- Matias visited Facility 2, Payer 4
    (4, 2, 2),  -- Karol visited Facility 2, Payer 2
    (5, 2, 2),  -- Jacobo visited Facility 2, Payer 2
    (5, 2, 3);  -- Jacobo visited Facility 2, Payer 3
