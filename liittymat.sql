--
-- PostgreSQL database dump
--

-- Dumped from database version 12.0
-- Dumped by pg_dump version 12.0

-- Started on 2019-11-29 14:14:08

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
-- TOC entry 203 (class 1259 OID 16736)
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
-- TOC entry 204 (class 1259 OID 16741)
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
-- TOC entry 205 (class 1259 OID 16747)
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

COPY public.liittyma (puhelinnumero, operaattori, datanopeus, hinta) FROM stdin;
\.


--
-- TOC entry 2830 (class 0 OID 16736)
-- Dependencies: 203
-- Data for Name: perusliittymat; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.perusliittymat (puhelinnumero, operaattori, datanopeus, hinta) FROM stdin;
223853	telia	100	10
791931	DNA	250	50
0	telia	100	100
451420	elisa	250	50
297980	elisa	100	10
\.


--
-- TOC entry 2831 (class 0 OID 16741)
-- Dependencies: 204
-- Data for Name: prepaidliittymat; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.prepaidliittymat (puhelinnumero, operaattori, datanopeus, hinta) FROM stdin;
172766	dna	50	10
118463	telia	100	19
315671	moi	200	20
\.


--
-- TOC entry 2832 (class 0 OID 16747)
-- Dependencies: 205
-- Data for Name: yritysliittymat; Type: TABLE DATA; Schema: public; Owner: postgres
--

COPY public.yritysliittymat (puhelinnumero, operaattori, datanopeus, hinta) FROM stdin;
769620	ewf	34	32
106970	elisa	100	10
750638	DNA	200	20
120734	elisa	200	20
667637	elisa	300	25
7	Dna	100	50
518124	moi	100	20
677123	telia	100	10
949757	telia	300	20
839388	telia	300	20
\.


--
-- TOC entry 2698 (class 2606 OID 16740)
-- Name: perusliittymat perusliittymat_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.perusliittymat
    ADD CONSTRAINT perusliittymat_pkey PRIMARY KEY (puhelinnumero);


--
-- TOC entry 2700 (class 2606 OID 16745)
-- Name: prepaidliittymat prepaidliittymat_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.prepaidliittymat
    ADD CONSTRAINT prepaidliittymat_pkey PRIMARY KEY (puhelinnumero);


--
-- TOC entry 2702 (class 2606 OID 16751)
-- Name: yritysliittymat yritysliittymat_pkey; Type: CONSTRAINT; Schema: public; Owner: postgres
--

ALTER TABLE ONLY public.yritysliittymat
    ADD CONSTRAINT yritysliittymat_pkey PRIMARY KEY (puhelinnumero);


-- Completed on 2019-11-29 14:14:09

--
-- PostgreSQL database dump complete
--

