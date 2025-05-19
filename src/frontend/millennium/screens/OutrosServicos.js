import React from 'react';
import { View, Text, StyleSheet, ScrollView, TouchableOpacity, ImageBackground } from 'react-native';

export default function OutrosServicos({ navigation }) {
  const servicos = [
    {
      titulo: 'PERFIL (ACABAMENTO/PÉZINHO)',
      descricao: 'É feito somente o acabamento do cabelo.',
      preco: 'R$ 10,00',
      duracao: '10 minutos',
    },
    {
      titulo: 'COMBO DEPILAÇÃO ORELHA + NARIZ',
      descricao: 'Depilação na orelha e no nariz com cera quente.',
      preco: 'R$ 35,00',
      duracao: '35 minutos',
    },
    {
      titulo: 'DEPILAÇÃO NARIZ COM CERA',
      descricao: 'Depilação do nariz utilizando cera quente.',
      preco: 'R$ 20,00',
      duracao: '20 minutos',
    },
    {
      titulo: 'ACABAMENTO DA BARBA',
      descricao: 'É feito somente a manutenção da barba. Os pêlos que cresceram onde passou a lâmina. Sem uso de toalha quente.',
      preco: 'R$ 15,00',
      duracao: '15 minutos',
    },
    {
      titulo: 'DEPILAÇÃO ORELHA COM CERA',
      descricao: 'Depilação na orelha com cera quente.',
      preco: 'R$ 20,00',
      duracao: '20 minutos',
    },
    {
      titulo: 'DIA DO NOIVO',
      descricao: 'Entrar em contato para combinar.',
      preco: 'Varia',
      duracao: '3 horas',
    },
    {
      titulo: 'LIMPEZA DE PELE',
      descricao: 'Limpeza de pele com remoção de cravos.',
      preco: 'R$ 80,00',
      duracao: '1h 20min',
    },
    {
      titulo: 'ALINHAMENTO DO BIGODE',
      descricao: 'É feito apenas o acabamento(pezinho) do bigode.',
      preco: 'R$ 15,00',
      duracao: '15 minutos',
    },
  ];

  return (
    <ImageBackground source={require('../assets/background-2.png')} style={styles.background}>
      <View style={styles.headerContainer}>
        <Text style={styles.title}>OUTROS SERVIÇOS</Text>
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
