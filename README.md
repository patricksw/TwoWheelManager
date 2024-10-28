# TwoWheelManager
Sistema de gestão para serviços logísticos de motos. 

API restfull para gestão de locações de motos. A API tem como principais operações a gestão para locação de motos, dentre essas operações devem-se cadastrar motos, entregadores e registrar as locações.
Para manter o cadastro das motos deve-se registar a moto via operação http post, depois é possível alterar a placa, recuperar moto via GET, também deletar do sistema.
Para manter os entregadores é possível registrar um novo entregador e também enviar seu documento, ambos via http post.
Para a locação, devem-se registrar uma nova locação via http post, também registrar a devolução. Sendo assim é possível calcular o total da diária e multas.

Tecnologias utilizadas:
1.	Api .NET C#
2.	MongoDb
3.	Kafka

Para iniciar o serviço local:
1.	Kafka tools (https://www.kafkatool.com/download.html)
2.	Docker (https://docs.docker.com/desktop/install/windows-install/)
3.	Install kafka image docker:
a.	docker pull apache/kafka:3.8.0	
b.	docker run -p 9092:9092 apache/kafka:3.8.0
4.	MongoDb (https://www.mongodb.com/try/download/community)
