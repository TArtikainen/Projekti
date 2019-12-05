--
-- PostgreSQL database dump
--

-- Dumped from database version 12.0
-- Dumped by pg_dump version 12.0

-- Started on 2019-12-05 19:51:37

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

DROP DATABASE "Kannykkaliittymat";
--
-- TOC entry 2838 (class 1262 OID 16464)
-- Name: Kannykkaliittymat; Type: DATABASE; Schema: -; Owner: postgres
--

CREATE DATABASE "Kannykkaliittymat" WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'Finnish_Finland.1252' LC_CTYPE = 'Finnish_Finland.1252';


ALTER DATABASE "Kannykkaliittymat" OWNER TO postgres;

\connect "Kannykkaliittymat"

SET statement_timeout = 0;
SET lock_timeout = 0;
SET idle_in_transaction_session_timeout = 0;
SET client_encoding = 'UTF8';
SET standard_conforming_strings = on;
SELECT pg_catalog.set_config('search_path', '', false);
SET check_function_bodies = false;
SET xmloption = content;
SET client_min_messages = warning;
SET row_security = off;

SET default_tablespace = '';

SET default_table_access_method = heap;

--
-- TOC entry 202 (class 1259 OID 16701)
-- Name: liittyma; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.liittyma (
    puhelinnumero integer,
    operaattori character varying(255),
    datanopeus integer,
    hinta integer
);


ALTER TABLE public.liittyma OWNER TO postgres;

--
-- TOC entry 204 (class 1259 OID 24903)
-- Name: perusliittymat; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.perusliittymat (
    puhelinnumero integer NOT NULL,
    operaattori character varying(255),
    datanopeus integer,
    hinta integer
);


ALTER TABLE public.perusliittymat OWNER TO postgres;

--
-- TOC entry 205 (class 1259 OID 24908)
-- Name: prepaidliittymat; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.prepaidliittymat (
    puhelinnumero integer NOT NULL,
    operaattori character varying(255),
    datanopeus integer,
    hinta integer
);


ALTER TABLE public.prepaidliittymat OWNER TO postgres;

--
-- TOC entry 203 (class 1259 OID 24893)
-- Name: yritysliittymat; Type: TABLE; Schema: public; Owner: postgres
--

CREATE TABLE public.yritysliittymat (
    puhelinnumero integer NOT NULL,
    operaattori character varying(255),
    datanopeus integer,
    hinta integer
);


ALTER TABLE public.yritysliittymat OWNER TO postgres;

--
-- TOC entry 2829 (class 0 OID 16701)
-- Dependencies: 202
-- Data for Name: liittyma; Type: TABLE DATA; Schema: public; Owner: postgres
--



--
-- TOC entry 2831 (class 0 OID 24903)
-- Dependencies: 204
-- Data for Name: perusliittymat; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.perusliittymat (puhelinnumero, operaattori, datanopeus, hinta) VALUES (350288, 'Telia', 100, 18);
INSERT INTO public.perusliittymat (puhelinnumero, operaattori, datanopeus, hinta) VALUES (581830, 'Elisa', 150, 23);
INSERT INTO public.perusliittymat (puhelinnumero, operaattori, datanopeus, hinta) VALUES (386948, 'DNA', 250, 29);
INSERT INTO public.perusliittymat (puhelinnumero, operaattori, datanopeus, hinta) VALUES (549322, 'Telia', 200, 25);


--
-- TOC entry 2832 (class 0 OID 24908)
-- Dependencies: 205
-- Data for Name: prepaidliittymat; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.prepaidliittymat (puhelinnumero, operaattori, datanopeus, hinta) VALUES (974278, 'Telia', 100, 14);
INSERT INTO public.prepaidliittymat (puhelinnumero, operaattori, datanopeus, hinta) VALUES (576153, 'Elisa', 200, 24);
INSERT INTO public.prepaidliittymat (puhelinnumero, operaattori, datanopeus, hinta) VALUES (566899, 'Dna', 150, 19);
INSERT INTO public.prepaidliittymat (puhelinnumero, operaattori, datanopeus, hinta) VALUES (588153, 'Elisa', 250, 29);


--
-- TOC entry 2830 (class 0 OID 24893)
-- Dependencies: 203
-- Data for Name: yritysliittymat; Type: TABLE DATA; Schema: public; Owner: postgres
--

INSERT INTO public.yritysliittymat (puhelinnumero, operaattori, datanopeus, hinta) VALUES (931112, 'Telia', 200, 25);
INSERT INTO public.yritysliittymat (puhelinnumero, operaattori, datanopeus, hinta) VALUES (314743, 'Elisa', 250, 32);
INSERT INTO public.yritysliittymat (puhelinnumero, operaattori, datanopeus, hinta) VALUES (480966, 'DNA', 150, 20);
INSERT INTO public.yritysliittymat (puhelinnumero, operaattori, datanopeus, hinta) VALUES (104221, 'Telia', 100, 15);


--
-- TOC entry 2700 (class 2606 OID 24907)
-- Name: perusliittymat perusliittymat_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.perusliittymat
    ADD CONSTRAINT perusliittymat_pkey PRIMARY KEY (puhelinnumero);


--
-- TOC entry 2702 (class 2606 OID 24912)
-- Name: prepaidliittymat prepaidliittymat_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.prepaidliittymat
    ADD CONSTRAINT prepaidliittymat_pkey PRIMARY KEY (puhelinnumero);


--
-- TOC entry 2698 (class 2606 OID 24897)
-- Name: yritysliittymat yritysliittymat_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.yritysliittymat
    ADD CONSTRAINT yritysliittymat_pkey PRIMARY KEY (puhelinnumero);


-- Completed on 2019-12-05 19:51:37

--
-- PostgreSQL database dump complete
--

