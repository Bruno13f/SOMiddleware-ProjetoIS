# Standard Service Oriented Middleware - Unidade Curricular IS 

Service-oriented Middleware

## Description

Designed to create a standardized approach for accessing, writing, and notifying data across various application domains. By leveraging Web Services and a Web-based resource structure built upon open standards, it advocates interoperability and open data principles. This ensures consistency in data access and application development, fostering seamless data accessibility and facilitating the creation of new services and applications across diverse domains.

### Project Objective:
UnifiedDataHub aims to establish a service-oriented middleware that standardizes data access, writing, and notification across various application domains, promoting interoperability and open data principles.
Along with the standard Middelware we created a application to manage study rooms of a library, as it can be seen in the attached image.

![IS](https://github.com/Bruno13f/SOMiddleware-ProjetoIS/assets/122650083/0b64eb64-67cd-4ac8-9726-6ec54bd86c1a)

### Resource Organization:
The middleware adopts a hierarchical structure comprising applications, containers, data records, and subscriptions. Applications can house multiple containers, each capable of containing data records and subscription mechanisms.

### Resource Attributes:
Distinct resource types (application, container, data, subscription) possess specific properties such as ID, name, creation date, and parent relationship. Notably, data and subscription resources lack update operations.

### RESTful API:
UnifiedDataHub offers a RESTful API facilitating creation, modification, listing, deletion, and discovery of available resources. API endpoints adhere to a structured URL format, with various operations discerned by virtual references in the URL.

### Subscription Mechanism:
Subscriptions support two event types (creation or deletion) and can trigger notifications via MQTT or HTTP endpoints. Notifications comprise the data resource, event type (creation or deletion), with channel names matching the source container resource path.

### Persistence:
The middleware ensures resource and data persistence in a database.

### Data Representation:
Transferred data adopts the XML format.

### HTTP Actions:
HTTP actions in RESTful requests target resources using their unique names rather than IDs.

### Resource Discovery:
Resource discovery is facilitated by the GET HTTP verb, alongside the HTTP header "somiod-discover: <res_type>". The response provides a list of resource names based on the specified resource type.

### Resource Attributes:
Each resource boasts specific attributes, including parent properties storing the unique ID of the parent resource, unique ID and name properties, simplified ISO date format for datetime, numeric values for the event property (1 for creation, 2 for deletion), MQTT and HTTP endpoint properties, automatic generation of unique names for resources without one, and a res_type property indicating the resource type in the HTTP body.
