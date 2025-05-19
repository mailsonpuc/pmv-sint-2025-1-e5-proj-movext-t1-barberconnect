import React from 'react';
import { View, Text, StyleSheet, TouchableOpacity, ImageBackground } from 'react-native';

export default function ServicosPopulares({ navigation }) {
  const servicos = [
    {
      titulo: 'CORTE DEGRADÊ/ TESOURA / MÁQUINA E TESOURA',
      descricao: 'Inclui lavagem e finalização do cabelo',
      preco: 'R$ 45,00',
      duracao: '50 minutos',
    },
    {
      titulo: 'COMBO ESPECIAL (CABELO + BARBA + SOBRANCELHAS)',
      descricao: '',
      preco: 'R$ 70,00',
      duracao: '1 hora',
    },
    {
      titulo: 'COMBO (CORTE + SOBRANCELHAS)',
      descricao: 'Corte degradê/ máquina e tesoura/ somente tesoura + sobrancelha na navalha.',
      preco: 'R$ 50,00',
      duracao: '50 minutos',
    },
  ];

  return (
    <ImageBackground source={require('../assets/background-2.png')} style={styles.background}>
      <View style={styles.headerContainer}>
        <Text style={styles.title}>SERVIÇOS MILLENNIUM BARBEARIA</Text>
      </View>

      <View style={styles.content}>
        {servicos.map((servico, index) => (
          <View key={index} style={styles.card}>
            <Text style={styles.servicoTitulo}>{servico.titulo}</Text>
            {servico.descricao !== '' && (
              <Text style={styles.descricao}>{servico.descricao}</Text>
            )}
            <Text style={styles.info}>{servico.preco}  |  {servico.duracao}</Text>
            <TouchableOpacity style={styles.button}
            onPress={() => navigation.navigate('Agendamento', { servico })}>
              <Text style={styles.buttonText}>AGENDAR</Text>
            </TouchableOpacity>
          </View>
        ))}
      </View>
    </ImageBackground>
  );
}

const styles = StyleSheet.create({
  background: {
    flex: 1,
  },
  headerContainer: {
    paddingTop: 50,
    paddingBottom: 10,
    alignItems: 'center',
  },
  title: {
    color: '#fff',
    fontSize: 20,
    fontWeight: 'bold',
  },
  content: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    paddingHorizontal: 20,
  },
  card: {
    backgroundColor: 'rgba(54,54,54,0.9)',
    borderRadius: 20,
    padding: 15,
    width: '100%',
    marginBottom: 20,
  },
  servicoTitulo: {
    color: '#fff',
    fontWeight: 'bold',
    textAlign: 'center',
    marginBottom: 5,
  },
  descricao: {
    color: '#fff',
    textAlign: 'center',
    marginBottom: 5,
  },
  info: {
    color: '#fff',
    textAlign: 'center',
    marginBottom: 10,
  },
  button: {
    backgroundColor: '#555',
    borderRadius: 10,
    paddingVertical: 10,
    alignItems: 'center',
  },
  buttonText: {
    color: '#fff',
    fontWeight: 'bold',
  },
});
