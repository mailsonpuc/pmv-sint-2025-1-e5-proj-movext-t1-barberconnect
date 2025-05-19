import React, { useState, useEffect } from 'react';
import {
  View,
  Text,
  StyleSheet,
  ImageBackground,
  FlatList,
  TouchableOpacity,
  Alert,
} from 'react-native';
import DateTimePicker from '@react-native-community/datetimepicker';
import PageContainer from '../components/PageContainer';

export default function AgendaBarbeiro() {
  const [dataSelecionada, setDataSelecionada] = useState(new Date());
  const [mostrarDatePicker, setMostrarDatePicker] = useState(false);
  const [agenda, setAgenda] = useState([]);

  useEffect(() => {
    const horarios = [
      { hora: '08:00', status: 'disponível' },
      { hora: '09:00', status: 'disponível' },
      { hora: '10:00', status: 'disponível' },
      { hora: '11:00', status: 'disponível' },
      { hora: '13:00', status: 'disponível' },
      { hora: '14:00', status: 'disponível' },
      { hora: '15:00', status: 'disponível' }
    ];
    setAgenda(horarios);
  }, [dataSelecionada]);

  const bloquearHorario = (hora) => {
    Alert.alert(
      'Confirmar Bloqueio',
      `Deseja bloquear o horário ${hora}?`,
      [
        { text: 'Cancelar', style: 'cancel' },
        {
          text: 'Confirmar',
          onPress: () => {
            setAgenda((prev) =>
              prev.map((item) =>
                item.hora === hora ? { ...item, status: 'bloqueado' } : item
              )
            );
          },
        },
      ]
    );
  };

  return (
    <ImageBackground
      source={require('../assets/home-background.png')}
      style={styles.background}
    >
      <PageContainer>
        <TouchableOpacity onPress={() => setMostrarDatePicker(true)}>
          <Text style={styles.dateLabel}>Data:</Text>
          <Text style={styles.dateValue}>{dataSelecionada.toLocaleDateString()}</Text>
        </TouchableOpacity>

        {mostrarDatePicker && (
          <DateTimePicker
            value={dataSelecionada}
            mode="date"
            display="default"
            onChange={(event, selectedDate) => {
              setMostrarDatePicker(false);
              if (selectedDate) setDataSelecionada(selectedDate);
            }}
          />
        )}

        <FlatList
          data={agenda}
          keyExtractor={(item) => item.hora}
          renderItem={({ item }) => (
            <View style={styles.card}>
              <Text style={styles.hora}>{item.hora}</Text>
              <Text style={styles.status}>
                {item.status === 'ocupado' ? `Agendado com ${item.cliente}` : item.status}
              </Text>
              {item.status === 'disponível' && (
                <TouchableOpacity
                  style={styles.botaoBloquear}
                  onPress={() => bloquearHorario(item.hora)}
                >
                  <Text style={styles.botaoTexto}>Bloquear</Text>
                </TouchableOpacity>
              )}
            </View>
          )}
        />
      </PageContainer>
    </ImageBackground>
  );
}

const styles = StyleSheet.create({
  background: {
    flex: 1,
  },
  dateLabel: {
    color: '#fff',
    fontWeight: '600',
    marginBottom: 5,
    marginTop: 80,
  },
  dateValue: {
    color: '#fff',
    marginBottom: 50,
  },
  card: {
    backgroundColor: 'rgba(54,54,54,0.9)',
    borderRadius: 10,
    padding: 15,
    marginBottom: 10,
    marginTop: 20,
  },
  hora: {
    color: '#fff',
    fontSize: 16,
    fontWeight: '600',
  },
  status: {
    color: '#ccc',
    fontSize: 14,
    marginBottom: 10,
  },
  botaoBloquear: {
    backgroundColor: '#900',
    paddingVertical: 8,
    borderRadius: 6,
    alignItems: 'center',
  },
  botaoTexto: {
    color: '#fff',
    fontWeight: 'bold',
  },
});
