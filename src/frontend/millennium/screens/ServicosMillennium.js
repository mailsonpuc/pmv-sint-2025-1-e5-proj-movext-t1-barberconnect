import React from 'react';
import { View, Text, StyleSheet, ScrollView, TouchableOpacity, ImageBackground } from 'react-native';

export default function ServicosMillennium({ navigation }) {
  const servicos = [
    {
      titulo: 'Corte Infantil',
      descricao: '',
      preco: 'R$ 45,00',
      duracao: '50min',
    },
    {
      titulo: 'Sobrancelhas (Navalha)',
      descricao: '',
      preco: 'R$ 10,00',
      duracao: '5min',
    },
    {
      titulo: 'Sobrancelhas (Pinça)',
      descricao: '',
      preco: 'R$ 25,00',
      duracao: '20min',
    },
    {
      titulo: 'Corte Simples (Até 2 Pentes)',
      descricao: 'Corte somente máquina, sem degradê. Até 2 pentes.',
      preco: 'R$ 30,00',
      duracao: '25min',
    },
    {
      titulo: 'Barba',
      descricao: 'Inclui toalha quente.',
      preco: 'R$ 35,00',
      duracao: '35min',
    },
    {
      titulo: 'Penteado',
      descricao: '',
      preco: 'R$ 30,00',
      duracao: '30min',
    },
    {
      titulo: 'Corte Degradê/ Tesoura / Máquina e Tesoura',
      descricao: 'Inclui lavagem e finalização do cabelo.',
      preco: 'R$ 45,00',
      duracao: '50min',
    },
    {
      titulo: 'Hidratação',
      descricao: 'Atenção: Este serviço tem valor inicial de R$20,00. O valor poderá alterar de acordo com o tipo e comprimento do cabelo do cliente.',
      preco: 'R$ 20,00+',
      duracao: '30min',
    },
    {
      titulo: 'Luzes',
      descricao: '',
      preco: 'R$ 180,00+',
      duracao: '1h 20min',
    },
    {
      titulo: 'Platinado',
      descricao: '',
      preco: 'R$ 250,00+',
      duracao: '1h 40min',
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
