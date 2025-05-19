import React from 'react';
import { View, Text, StyleSheet, ScrollView, TouchableOpacity, ImageBackground } from 'react-native';

export default function CombosMillennium({ navigation }) {
  const servicos = [
    {
      titulo: 'COMBO (CORTE + SOBRANCELHAS)',
      descricao: 'Corte degradê/ máquina e tesoura/ somente tesoura + sobrancelha na navalha.',
      preco: 'R$ 50,00',
      duracao: '50 minutos',
    },
    {
      titulo: 'BARBA + RASPAGEM TOTAL DO CABELO (NAVALHA SHAVER)',
      descricao: 'Raspagem do cabelo todo na navalha ou máquina shaver + barba (inclui toalha quente).',
      preco: 'R$ 70,00',
      duracao: '1 hora',
    },
    {
      titulo: 'COMBO SIMPLES (CORTE SIMPLES + BARBA)',
      descricao: 'Corte somente máquina, até 2 pentes + barba (inclui toalha quente).',
      preco: 'R$ 55,00',
      duracao: '55 minutos',
    },
    {
      titulo: 'COMBO ESPECIAL (CABELO + BARBA + SOBRANCELHAS)',
      preco: 'R$ 70,00',
      duracao: '1 hora',
    },
    {
      titulo: 'PIGMENTAÇÃO + CORTE',
      preco: 'R$ 70,00',
      duracao: '1h 30min',
    },
    {
      titulo: 'PROGRESSIVA + CORTE',
      descricao: 'Este serviço tem valor inicial de R$90,00. O valor poderá alterar de acordo com o tipo e comprimento do cabelo do cliente.',
      preco: 'R$ 90,00+',
      duracao: '1h 30min',
    },
  ];

  return (
    <ImageBackground source={require('../assets/background-2.png')} style={styles.background}>
      <View style={styles.headerContainer}>
        <Text style={styles.title}>SERVIÇOS MILLENNIUM BARBEARIA</Text>
      </View>

      <ScrollView contentContainerStyle={styles.container}>
        {servicos.map((servico, index) => (
          <View key={index} style={styles.card}>
            <Text style={styles.servicoTitulo}>{servico.titulo}</Text>
            <Text style={styles.descricao}>{servico.descricao}</Text>
            <Text style={styles.info}>{servico.preco}  |  {servico.duracao}</Text>
            <TouchableOpacity style={styles.button}
            onPress={() => navigation.navigate('Agendamento', { servico })}>
              <Text style={styles.buttonText}>AGENDAR</Text>
            </TouchableOpacity>
          </View>
        ))}
      </ScrollView>
    </ImageBackground>
  );
}

const styles = StyleSheet.create({
  background: { flex: 1 },
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
  container: {
    padding: 20,
    alignItems: 'center',
    paddingBottom: 50,
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
