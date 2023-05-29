from concurrent import futures
import logging
import rospy
import grpc
import grpc_pb2
import grpc_pb2_grpc
from geometry_msgs.msg import PointStamped

#Creamos la clase GRPC
class GRPC(grpc_pb2_grpc.GRPCServicer):
    #Metodo para inicializar los datos del servidor
    def __init__(self):
        self.data = [0,0]
        rospy.Subscriber('/coords', PointStamped, self.updateData)

    #Actualizamos los datos cada vez que el topic manda mensaje
    def updateData(self,msg):
        self.data[0] = msg.point.x
        self.data[1] = msg.point.y

    #Metodo del server para mandar las coordenadas
    def GetCoordinates(self,request,context):
        val = [self.data[0],self.data[1]]
        return grpc_pb2.Coordinates(x=self.data[0], y =self.data[1])

#Iniciamos el server y sus caracteristicas
def serve():
    port = '50051'
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    grpc_pb2_grpc.add_GRPCServicer_to_server(GRPC(), server)
    server.add_insecure_port('[::]:' + port)
    server.start()
    print("Server started, listening on " + port)
    server.wait_for_termination()


if __name__ == '__main__':
    logging.basicConfig()
    rospy.init_node('grpc')
    serve()